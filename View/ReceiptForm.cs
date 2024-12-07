using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEUProject_CSharp_OutbackPOS.Model;
using DEUProject_CSharp_OutbackPOS.Controller;

namespace DEUProject_CSharp_OutbackPOS.View
{
    public partial class ReceiptForm : Form
    {
        private readonly PaymentController paymentController;

        public ReceiptForm()
        {
            InitializeComponent();
            paymentController = new PaymentController();
            LoadReceiptData();
        }

        public void LoadReceiptData()
        {
            var payments = paymentController.GetAllPayments();
            var receiptData = new List<dynamic>();

            foreach (var payment in payments)
            {
                foreach (var order in payment.Orders)
                {
                    foreach (var item in order.outbackOrderItem)
                    {
                        receiptData.Add(new
                        {
                            PaymentId = payment.Id,
                            TotalAmount = payment.TotalAmount,
                            OrderId = order.OrderID,
                            MenuName = item.MenuName,
                            Quantity = item.Quantity
                        });
                    }
                }
            }

            ReceiptDataGridView.DataSource = receiptData;
        }

        private void btnReceiptRemove_Click(object sender, EventArgs e)
        {
            if (ReceiptDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = ReceiptDataGridView.SelectedRows[0];
                int paymentId = (int)selectedRow.Cells["PaymentId"].Value;

                paymentController.DeletePayment(paymentId);
                LoadReceiptData();
            }
            else
            {
                MessageBox.Show("삭제할 영수증을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}