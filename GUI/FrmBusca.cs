using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MP;

namespace GUI
{
    public partial class FrmBusca : Form
    {

        private IList<Card> deck = new List<Card>();

        public FrmBusca()
        {
            InitializeComponent();
            ClearList(lstResults);
            ClearList(lstEditions);
            ClearList(lstDeck);
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
            if (lstResults.SelectedItems.Count == 1)
            {
                MP.Card card = (MP.Card)lstResults.SelectedItem;

                ClearList(lstEditions);

                foreach (MP.Edition edition in card.Editions)
                {

                    lstEditions.Items.Add(edition);
                }

                if (card.Editions.Where(edition => edition.Price == null).Count() > 0)
                {
                    MessageBox.Show(this, "Há edições da carta selecionada que não possuem preço. Não será possível adicionar as mesmas à seu deck.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (lstResults.SelectedItems.Count != 1)
            {
                MessageBox.Show(this, "Selecione UMA carta.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lstEditions.SelectedItems.Count != 1)
            {
                MessageBox.Show(this, "Selecione UMA edição.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = 0;
            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show(this, "O campo quantidade deve ser numérico.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(quantity >= 0))
            {
                MessageBox.Show(this, "Quantidade deve ser maior ou igual a zero.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Card card = new Card((Card)lstResults.SelectedItem);
            card.Quantity = quantity;

            Edition edition = (Edition)lstEditions.SelectedItem;

            if (edition.Price == null)
            {
                MessageBox.Show(this, "A edição desejada não possui preço.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Core.SetSelectedEdition(card, edition);

            deck.Add(card);

            RefreshDeckList();

        }

        private void RefreshDeckList()
        {
            ClearList(lstDeck);
            foreach (Card c in deck.OrderByDescending(p => p.SelectedEdition.Price.Average * p.Quantity).ToList())
            {
                lstDeck.Items.Add(c);
            }

            lblTotal.Text = MP.Core.Sum(deck).ToString();
        }

        private void lstEditions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
