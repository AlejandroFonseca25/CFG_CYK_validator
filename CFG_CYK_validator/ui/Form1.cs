﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFG_CYK_validator.ui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            catch(FormatException)
            {
                MessageBox.Show("Wrong input. Please enter a number and try again", "Oops!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }                     
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {

            if (Table.Rows.Count == 0)
            {
                MessageBox.Show("The table is empty. Please generate a CFG and try again", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                List<Tuple<string, List<string>>> Cfg = new List<Tuple<string, List<string>>>();
                List<string> vars = new List<string>();

                foreach (DataGridViewRow row in Table.Rows)
                {
                    List<string> productions = new List<String>();
                    string var = Convert.ToString(row.Cells["VariableColumn"].Value);
                    string[] prods = Convert.ToString(row.Cells["ProductionColumn"].Value).Split(',');
                    if (VariableIsValid(var, vars) && ProductionIsValid(prods))
                    {
                        productions.AddRange(prods);
                        Cfg.Add(new Tuple<string, List<string>>(var, productions));
                        vars.Add(var);
                    }
                    else
                    {
                        MessageBox.Show("Remember that the CFG must be in Chomsky Normal Form", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Wrong input. Please check the values on the table and try again", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private bool VariableIsValid(string var,List<string> vars)
        {
            bool ans = true;
            if (var.Length > 1)
            {
                ans= false;
                Console.WriteLine(var + " 4");
            }
            else if (!Char.IsUpper(var[0]))
            {
                ans= false;
                Console.WriteLine(var + " 5");
            }
            else if (vars.Contains(var))
            {
                ans= false;
                Console.WriteLine(var + " 6");
            }
            return ans;
        }
        private bool ProductionIsValid(string[] prods)
        {
            bool ans = true;
            foreach(string prod in prods)
            {
                if (prod.Length > 2)
                {
                    ans = false;
                    Console.WriteLine(prod + " 1");
                }
                else if (prod.Length == 2)
                {
                    if (!Char.IsUpper(prod[0]) || !Char.IsUpper(prod[1]))
                    {
                        ans = false;
                        Console.WriteLine(prod + " 2");
                    }
                }
                else if (prod.Length == 1)
                {
                    if (Char.IsUpper(prod[0]))
                    {
                        ans = false;
                        Console.WriteLine(prod + " 3");
                    }
                }
            }          
            return ans;
        }

    }
}
