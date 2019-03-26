using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Redis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                //string redisconf = "127.0.0.1:12306,password=90-=uiop,DefaultDatabase=0";
                string redisconf = "127.0.0.1:12306,password=sy123456,connectTimeout=1000,connectRetry=1,syncTimeout=10000,DefaultDatabase=0";
                RedisHelper.SetCon(redisconf);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox2.Text == null)
            {
                textBox1.Text = "请填写键";
                return;
            }
            if (textBox3.Text == "" || textBox3.Text == null)
            {
                textBox1.Text = "请填写值";
                return;
            }
            if (textBox4.Text == "" || textBox4.Text == null)
            {
                textBox1.Text = "请填写过期时间";
                return;
            }
            //设置
            RedisHelper.Set(textBox2.Text, textBox3.Text, int.Parse(textBox4.Text));//键,值,过期时间
            textBox1.Text = "添加成功";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null && textBox2.Text != "")
            {
                if (RedisHelper.Exists(textBox2.Text))
                {
                    //读取
                    textBox1.Text = RedisHelper.Get(textBox2.Text).ToString();
                }
                else
                {
                    textBox1.Text = "已过期或不存在";
                }
            }
            else {
                textBox1.Text = "请填写键";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null && textBox2.Text != "")
            {
                if (RedisHelper.Exists(textBox2.Text))
                {
                    //删除
                    RedisHelper.Remove(textBox2.Text).ToString();
                    textBox1.Text = "删除成功";
                }
                else
                {
                    textBox1.Text = "已过期或不存在";
                }
            }
            else
            {
                textBox1.Text = "请填写键";
            }
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
