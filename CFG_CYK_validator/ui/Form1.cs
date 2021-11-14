using CFG_CYK_validator.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CFG_CYK_validator.ui
{
    public partial class Form1 : Form
    {
        private CykValidator cyk;

        public Form1()
        {
            InitializeComponent();
            cyk = new CykValidator();
        }

        private void GenerateTableButton_Click(object sender, EventArgs e)
        {
            try
            {
                int rows = Convert.ToInt32(VariableTextBox.Text);
                Table.Rows.Clear();
                for (int i = 0; i < rows; i++)
                {
                    if (i == 0)
                    {
                        Table.Rows.Add("S", "prod1,prod2");
                        Table.Rows[0].Cells[0].ReadOnly = true;
                    }
                    else
                    {
                        Table.Rows.Add("", "");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Wrong input. Please enter a number and try again.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            if (Table.Rows.Count == 0)
            {
                MessageBox.Show("The table is empty. Please generate a CFG and try again.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                List<Tuple<string, List<string>>> cfg = new List<Tuple<string, List<string>>>();
                List<string> vars = new List<string>();
                int cont = 0;
                foreach (DataGridViewRow row in Table.Rows)
                {
                    List<string> productions = new List<String>();
                    string var = Convert.ToString(row.Cells["VariableColumn"].Value);
                    string[] prods = Convert.ToString(row.Cells["ProductionColumn"].Value).Split(',');
                    if (VariableIsValid(var, vars) && ProductionIsValid(prods, cont))
                    {
                        productions.AddRange(prods);
                        cfg.Add(new Tuple<string, List<string>>(var, productions));
                        vars.Add(var);
                    }
                    else
                    {
                        MessageBox.Show("Remember that the CFG must be in Chomsky Normal Form.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    cont++;
                }

                cyk.Init(cfg);
                bool valid = cyk.ValidateChain(ChainTextBox.Text);

                if (valid)
                {
                    MessageBox.Show("The chain is generated.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (!valid)
                {
                    MessageBox.Show("The chain is not generated.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Wrong input. Please check the values on the table and try again.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VariableIsValid(string var, List<string> vars)
        {
            bool ans = true;
            if (var.Length > 1)
            {
                ans = false;
            }
            else if (!Char.IsUpper(var[0]))
            {
                ans = false;
            }
            else if (vars.Contains(var))
            {
                ans = false;
            }
            return ans;
        }

        private bool ProductionIsValid(string[] prods, int cont)
        {
            bool ans = true;
            foreach (string prod in prods)
            {
                if (prod.Length > 2)
                {
                    ans = false;
                }
                else if (prod.Length == 2)
                {
                    if (!Char.IsUpper(prod[0]) || !Char.IsUpper(prod[1]))
                    {
                        ans = false;
                    }
                }
                else if (prod.Length == 1)
                {
                    if (prod[0].Equals('#') && cont >= 1)
                    {
                        ans = false;
                    }
                    else if (Char.IsUpper(prod[0]) || (!Char.IsLetter(prod[0]) && !prod[0].Equals('#')))
                    {
                        ans = false;
                    }
                }
            }
            return ans;
        }
    }
}