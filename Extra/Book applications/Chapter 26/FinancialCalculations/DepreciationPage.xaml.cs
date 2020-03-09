using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI;
using Windows.UI.Popups;





// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace FinancialCalculations
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class DepreciationPage : FinancialCalculations.Common.LayoutAwarePage
    {
        public DepreciationPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void pageRoot_Loaded(object sender, RoutedEventArgs e)
        {
            // populate the Life combo box with ints from 1 to 40
            for (int i = 1; i <= 40; i++)
                cboLife.Items.Add(i);
            cboLife.SelectedIndex = 4;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (IsValidData())
                {
                    double cost = Convert.ToDouble(txtInitialCost.Text);
                    double salvage = Convert.ToDouble(txtFinalValue.Text);
                    lstDepreciation.Items.Clear();
                    int life = Convert.ToInt32(cboLife.SelectedItem);
                    double dLife = (double)life;

                    for (int i = 1; i <= life; i++)
                    {
                        double period = (double)i;
                        double yearlyAllowance =
                            CalculateSYDDepreciation(
                            cost, salvage, dLife, period);
                        lstDepreciation.Items.Add(
                            "Year " + i + ": " + yearlyAllowance.ToString("c"));
                                        }
                    txtInitialCost.Focus(FocusState.Programmatic);
                }
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog(ex.Message + "\n\n" +
                    ex.GetType().ToString() + "\n" +
                    ex.StackTrace, "Exception");
                    var result = msg.ShowAsync();
            
            }

                 
        
            // This calls the Xaml animation that changes the text color of the list box
           ChangeListColor.Begin();

        }




        public bool IsValidData()
        {
            return
                // Validate the Initial Cost text box
                Validator.IsPresent(txtInitialCost) &&
                Validator.IsDecimal(txtInitialCost) &&
                Validator.IsWithinRange(txtInitialCost, 500, 1000000) &&

                // Validate the Final Value text box
                Validator.IsPresent(txtFinalValue) &&
                Validator.IsDecimal(txtFinalValue) &&
                Validator.IsWithinRange(txtFinalValue, 0, 10000000);
        }

        private double CalculateSYDDepreciation(double cost,
            double salvage, double life, double period)
        {
            double SYDValue =
                (cost - salvage) * (life - period + 1) * 2 /
                ((life) * (life + 1));
            return SYDValue;
        }

        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            txtInitialCost.Text = "";
            txtFinalValue.Text = "";
            cboLife.SelectedIndex = 4;
            lstDepreciation.Items.Clear();

        }

         



    }


}
