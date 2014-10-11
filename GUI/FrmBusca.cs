using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmBusca : Form
    {
        public FrmBusca()
        {
            InitializeComponent();
            ClearList(lstResults);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string searchField = txtCardName.Text;

            if (searchField.Length < 3)
            {
                MessageBox.Show(this, "Nome da carta deve conter ao menos 3 caracteres.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ClearList(lstResults);
                ClearList(lstEditions);

                IList<MP.Card> cardList = MP.Core.Search(searchField);

                foreach (MP.Card c in cardList)
                {
                    lstResults.Items.Add(c);
                }
            }
        }

        /// <summary>
        /// Clean the list box
        /// </summary>
        /// <param name="box">The list box to be erased</param>
        private void ClearList(ListBox box)
        {
            box.Items.Clear();
        }

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            MP.Card card = (MP.Card)lstResults.SelectedItem;

            ClearList(lstEditions);

            foreach (MP.Edition edition in card.Editions)
            {
                
                lstEditions.Items.Add(edition);
            }
        }


    }
}
