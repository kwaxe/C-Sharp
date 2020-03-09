using System;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Popups;


namespace FinancialCalculations
{
  

	public static class Validator
	{
		private static string title = "Entry Error";

		public static string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
			}
		}

		public static bool IsPresent(TextBox textBox)
		{
			if (textBox.Text == "")
			{
				MessageDialog msg = new MessageDialog(textBox.Tag + " is a required field.", Title);
				var result = msg.ShowAsync();   
				textBox.Focus(FocusState.Programmatic);
				return false;
			}
			return true;
		}

		public static bool IsDecimal(TextBox textBox)
		{
			try
			{
				Convert.ToDecimal(textBox.Text);
				return true;
			}
			catch (FormatException)
			{
				MessageDialog msg = new MessageDialog(textBox.Tag + " must be a decimal number.", Title);
				var result = msg.ShowAsync();
				textBox.Focus(FocusState.Programmatic);
				return false;
			}
		}

		public static bool IsInt32(TextBox textBox)
		{
			try
			{
				Convert.ToInt32(textBox.Text);
				return true;
			}
			catch (FormatException)
			{
				MessageDialog msg = new MessageDialog(textBox.Tag + " must be an integer.", Title);
				var result = msg.ShowAsync();
				textBox.Focus(FocusState.Programmatic);
				return false;
			}
		}

		public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
		{
			decimal number = Convert.ToDecimal(textBox.Text);
			if (number < min || number > max)
			{
				MessageDialog msg = new MessageDialog(textBox.Tag + " must be between " + min
					+ " and " + max + ".", Title);
				var result = msg.ShowAsync();
				textBox.Focus(FocusState.Programmatic);
				return false;
			}
			return true;
		}
	}
}
