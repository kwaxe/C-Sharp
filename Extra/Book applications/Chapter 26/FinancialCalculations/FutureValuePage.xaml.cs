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
using Windows.UI.Popups;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace FinancialCalculations
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class FutureValuePage : FinancialCalculations.Common.LayoutAwarePage
    {
        public FutureValuePage()
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

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (IsValidData())
                {
                    decimal monthlyInvestment =
                        Convert.ToDecimal(txtMonthlyInvestment.Text);
                    decimal interestRateYearly =
                        Convert.ToDecimal(txtInterestRate.Text);
                    int years = Convert.ToInt32(txtYears.Text);

                    int months = years * 12;
                    decimal interestRateMonthly = interestRateYearly / 12 / 100;
                    decimal futureValue = CalculateFutureValue(
                        monthlyInvestment, interestRateMonthly, months);

                    tblkFutureValue.Text = futureValue.ToString("c");
                    txtMonthlyInvestment.Focus(FocusState.Programmatic);
                }
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog(ex.Message + "\n\n" +
                     ex.GetType().ToString() + "\n" +
                     ex.StackTrace, "Exception");
                var result =  msg.ShowAsync();
            }

      
            //  animation using Xaml - created in Blend
            DropDownResult.Begin();
        
        }



        public bool IsValidData()
        {
            return
                // Validate the Monthly Investment text box
                Validator.IsPresent(txtMonthlyInvestment) &&
                Validator.IsDecimal(txtMonthlyInvestment) &&
                Validator.IsWithinRange(txtMonthlyInvestment, 1, 1000) &&

                // Validate the Yearly Interest Rate text box
                Validator.IsPresent(txtInterestRate) &&
                Validator.IsDecimal(txtInterestRate) &&
                Validator.IsWithinRange(txtInterestRate, 1, 20) &&

                // Validate the Number of Years text box
                Validator.IsPresent(txtYears) &&
                Validator.IsInt32(txtYears) &&
                Validator.IsWithinRange(txtYears, 1, 40);
        }

        private decimal CalculateFutureValue(decimal monthlyInvestment,
            decimal interestRateMonthly, int months)
        {
            decimal futureValue = 0m;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                    * (1 + interestRateMonthly);
            }

            return futureValue;
        }

        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            txtMonthlyInvestment.Text = "";
            txtInterestRate.Text = "";
            txtYears.Text = "";
            tblkFutureValue.Text = "";
        }
    }
}
