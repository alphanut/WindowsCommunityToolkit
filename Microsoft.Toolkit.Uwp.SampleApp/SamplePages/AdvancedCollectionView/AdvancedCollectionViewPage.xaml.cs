// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.ObjectModel;
using Collections.Generic;
using Microsoft.Toolkit.Uwp.UI;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Toolkit.Uwp.SampleApp.SamplePages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdvancedCollectionViewPage : Page
    {
        public AdvancedCollectionViewPage()
        {
            this.InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            var people = new[]
            {
                new Person { Name = "Staff" },
                new Person { Name = "42" },
                new Person { Name = "Swan" },
                new Person { Name = "Orchid" },
                new Person { Name = "15" },
                new Person { Name = "Flame" },
                new Person { Name = "16" },
                new Person { Name = "Arrow" },
                new Person { Name = "Tempest" },
                new Person { Name = "23" },
                new Person { Name = "Pearl" },
                new Person { Name = "Hydra" },
                new Person { Name = "Lamp Post" },
                new Person { Name = "4" },
                new Person { Name = "Looking Glass" },
                new Person { Name = "8" },
            };

            // left list
            var oc = new ObservableCollection<Person>(people);
            LeftList.ItemsSource = oc;

            // right list
            var acv = new AdvancedCollectionView(oc);
            int nul;
            acv.Filter = x => !int.TryParse(((Person)x).Name, out nul);
            acv.SortDescriptions.Add(new SortDescription("Name", SortDirection.Ascending));
            RightList.ItemsSource = acv;

            // datagrid
            // var vc = new ObservableVector<Person>(people); // This causes exception when adding as itemsource to datagrid: 
            var vc = acv;
            Datagrid.ItemsSource = vc;

            // add button
            AddButton.Click += (sender, args) =>
            {
                if (!string.IsNullOrWhiteSpace(NewItemBox.Text))
                {
                    oc.Add(new Person { Name = NewItemBox.Text });
                }
            };

            RemoveButton.Click += (sender, args) =>
            {
                if (Datagrid.SelectedItem != null)
                {
                    acv.Remove(Datagrid.SelectedItem);
                }
            };
        }
    }
}