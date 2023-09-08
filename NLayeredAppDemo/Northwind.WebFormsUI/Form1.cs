using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Business.DependencyResolvers.Ninject;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Concrete.Nhibarnate;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();

        }
        private ICategoryService _categoryService;
        private IProductService _productService;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            cbxCategory2.DataSource = _categoryService.GetAll();
            cbxCategory2.DisplayMember = "CategoryName";
            cbxCategory2.ValueMember = "CategoryId";


        }

        private void LoadProducts()
        {
            DgwProduct.DataSource = _productService.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DgwProduct.DataSource = _productService.GetProductByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            {


            }

        }

        private void txbProduct_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txbProduct.Text))
            {
                LoadProducts();

            }
            else
            {
                DgwProduct.DataSource = _productService.GetProductByProductName(txbProduct.Text);
            }




        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    ProductName = tbxProductName2.Text,
                    CategoryId = Convert.ToInt32(cbxCategory2.SelectedValue),
                    UnitPrice = Convert.ToDecimal(tbxPrice.Text),
                    QuantityPerUnit = tbxQuantity.Text,
                    UnitsInStock = Convert.ToInt16(tbxStock.Text),




                });
                LoadProducts();

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
           







        }

        private void DgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = DgwProduct.CurrentRow;
            tbxProductName2.Text = row.Cells[1].Value.ToString();
            cbxCategory2.SelectedValue = row.Cells[2].Value;
            tbxPrice.Text = row.Cells[3].Value.ToString();
            tbxStock.Text = row.Cells[5].Value.ToString();
            tbxQuantity.Text = row.Cells[4].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductID = Convert.ToInt32(DgwProduct.CurrentRow.Cells[0].Value),
                ProductName = tbxProductName2.Text,
                CategoryId = Convert.ToInt32(cbxCategory2.SelectedValue),
                UnitPrice = Convert.ToDecimal(tbxPrice.Text),
                UnitsInStock = Convert.ToInt16(tbxStock.Text),
                QuantityPerUnit = tbxQuantity.Text,



            });
            LoadProducts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DgwProduct.CurrentRow != null)
            {

                try
                {
                    _productService.Delete(new Product
                    {
                        ProductID = Convert.ToInt32(DgwProduct.CurrentRow.Cells[0].Value),


                    });
                    LoadProducts();
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message);
                }
                

                




            }
        }
    }
}
