﻿using CinemaTicketSalesAutomation.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaTicketSalesAutomation
{
    public partial class Form2 : Form
    {
        public Form2(List<Movie> _movies, Sinema_Seanslari _form1)
        {
            InitializeComponent();
            movies = _movies;
            form1 = _form1;

        }
        List<Movie> movies;
        Sinema_Seanslari form1;
        Movie selectedMovie;
        Session selectedSession;



        public void ListDetail(int movieIndex, string _time, string _date)
        {
            selectedMovie = movies[movieIndex];
            selectedSession = selectedMovie.sessions.Find(n => n.time == _time && n.date == _date);
            lblTime.Text = $"{_date} - {_time}";
            lblMinute.Text = selectedMovie.minute;
            lblPrice.Text = selectedMovie.price.ToString() + "tl";
            pbSelectedPic.Image = Image.FromFile(selectedMovie.picturePath);
            lblCategory.Text = selectedMovie.category.ToString();
            CheckChairsStatus();
        }

        private void CheckChairsStatus()
        {
            foreach (Control item in grpChairs.Controls)
            {
                if(item is Button)
                {
                    string row = (string)item.Tag;
                    string number = item.Text;
                    item.Enabled = true;
                    foreach (Chair chair in selectedSession.chairs)
                    {
                        if(chair.row == row && chair.number == number)
                        {
                            if (chair.status)
                            {
                                                     
                                item.BackColor = Color.DarkRed;
                                item.Enabled = false;

                            }
                            else
                            {
                                item.BackColor = Color.LightGreen;
                            }
                            break;
                        }
                    }

                }
            }
        }

        List<Chair> chairs = new List<Chair>();
        private void button24_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string row = button.Tag.ToString();
            string number = button.Text;
            Chair chair = selectedSession.chairs.Find(x => x.number == number && x.row == row);
            if (button.BackColor.Name != "Blue")
            {
                chairs.Add(chair);
                button.BackColor = Color.Blue;
            }
            else
            {
                chairs.Remove(chair);
                button.BackColor = Color.LightGreen;
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (chairs.Count == 0)
            {
                MessageBox.Show("Lütfen en az 1 koltuk seçiniz!");
                return;
            }
            Sales sales = new Sales();
            sales.movieName = selectedMovie.movieName;
            sales.count = chairs.Count;
            sales.sessionTime = $"{selectedSession.date} -  {selectedSession.time}";
            sales.totalPrice = CalculatePrice();
            foreach (Chair chair in chairs)
            {
                chair.status = true;
            }
            MessageBox.Show(sales.ToString());
            ChangePage();


        }

        private void ChangePage ()
        {
            rbLarge.Checked = rbMiddle.Checked = rbSmall.Checked = false;
            chairs.Clear();
            this.Hide();
            form1.Show();
       
        }

        private decimal CalculatePrice()
        {
            decimal price = selectedMovie.price * chairs.Count;

            if(rbSmall.Checked)
            {
                price += 3;

            }
            else if (rbMiddle.Checked)
            {
                price += 6;
            }
            else if (rbLarge.Checked)
            {
                price += 9;
            }

            return price;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChangePage();
        }
    }




}
