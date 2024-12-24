﻿using System;
using System.Windows.Controls;

namespace WpfApp.MVVM.Views; 

public partial class HomeView : UserControl {
	public HomeView() {
		InitializeComponent();
	}

	private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		(sender as ComboBox).SelectedIndex = -1;
	}
}