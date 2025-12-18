using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACTICITY_3
{
    public partial class FastFoodRestaurant : Form
    {
        public FastFoodRestaurant()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameofcustomer.Text))
            {
                MessageBox.Show("Please enter the name of the customer.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameofcustomer.Focus();
                return;
            }

            if (!chkBurger.Checked && chkHotdog.Checked && chkPizza.Checked && chkChicken.Checked)
            {
                MessageBox.Show("Please select at least one food item.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rdoDinein.Checked && !rdoTakeOut.Checked)
            {
                MessageBox.Show("Please select a dining option.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double total = 0;
            string MainDish = "", OptionalExtras = chkCheese.ToString() ?? "None";
            string diningOption = rdoDinein.Checked ? "Dine-in" : "Take-out";

            if (chkBurger.Checked)
            {
                MainDish += "Burger ";
                total += 120;

            }
            if (chkChicken.Checked)
            {
                MainDish += "Chicken ";
                total += 130;
            }
            if (chkHotdog.Checked)
            {
                MainDish += "Hotdog";
                total += 90;
            }
            if (chkPizza.Checked)
            {
                MainDish += "Pizza";
                total += 150;
            }

            else if (chkPizza.Checked)
            {
                OptionalExtras += "Cheese ";
                total += 20;
            }
            else if (chkChicken.Checked)
            {
                OptionalExtras += "Bacon ";
                total += 30;
            }
            if (OptionalExtras == "Fries")
            {
                OptionalExtras += "Fries ";
                total += 50;
            }
            else if (OptionalExtras == "Drinks")
            {
                OptionalExtras += "Drinks ";
                total += 40;
            }

            if (MainDish.EndsWith(","))
                MainDish = MainDish.Substring(0, MainDish.Length - 1);

            txtAmounttopay.Text = "P" + total.ToString("0.00");

            DialogResult result = MessageBox.Show(
                $"Customer Name: {txtNameofcustomer.Text}\n" +
                $"Main Dish: {MainDish}\n" +
                $"Optional Extras: {OptionalExtras}\n" +
                $"Dining Option: {diningOption}\n" +
                $"Total Amount to Pay: P{total:0.00}\n\n" +
                "Do you want to confirm the order?",
                "Order Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
             if (result == DialogResult.OK)
            {
                MessageBox.Show("Order confirmed! Thank you for dining with us.", "Order Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNameofcustomer.Clear();
            chkBurger.Checked = chkHotdog.Checked = chkPizza.Checked = chkChicken.Checked = false;
            chkCheese.Checked = chkBacon.Checked = chkDrink.Checked = chkFries.Checked = false;
            txtAmounttopay.Clear();
            rdoDinein.Checked = rdoTakeOut.Checked = false;
        }

        private void FastFoodRestaurant_Load(object sender, EventArgs e)
        {

        }
    }
}
