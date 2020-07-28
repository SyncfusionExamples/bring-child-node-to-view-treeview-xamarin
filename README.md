# How to bring the TreeView child node to view when the root node is collapsed in Xamarin.Forms (SfTreeView)

You can programmatically bring the child node to the view when all the root nodes are collapsed using [BringIntoView](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfTreeView.XForms~Syncfusion.XForms.TreeView.SfTreeView~BringIntoView.html) method by expanding the particular root node in Xamarin.Forms [SfTreeView](https://help.syncfusion.com/xamarin/treeview/overview).

You can also refer the following article.

https://www.syncfusion.com/kb/11802/how-to-bring-the-treeview-child-node-to-view-when-the-root-node-is-collapsed-in-xamarin

**C#**

In the [Button.Clicked](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.button.clicked) event, bring any child item using [BringIntoView](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfTreeView.XForms~Syncfusion.XForms.TreeView.SfTreeView~BringIntoView.html) method.

``` c#
public class Behavior : Behavior<ContentPage>
{
    SfTreeView TreeView;
    Button Button;

    protected override void OnAttachedTo(ContentPage bindable)
    {
        TreeView = bindable.FindByName<SfTreeView>("treeView");
        Button = bindable.FindByName<Button>("button");
        Button.Clicked += Button_Clicked;
        base.OnAttachedTo(bindable);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var viewModel = (sender as SfTreeView).BindingContext as FileManagerViewModel;
        var item = viewModel.ImageNodeInfo[3].SubFiles[1];

        if (item != null)
        {
            if (ExpandToSelection(TreeView, TreeView.Nodes, item))
            {
                TreeView.BringIntoView(item, true);
                TreeView.SelectedItem = item;
            }
        }
    }
}
```
Expands the all the parent nodes using [ExpandNode](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfTreeView.XForms~Syncfusion.XForms.TreeView.SfTreeView~ExpandNode.html) method. The **ExpandToSelection** method gets called recursively until the root node is reached based on the [HasChildNodes](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfTreeView.XForms~Syncfusion.TreeView.Engine.TreeViewNode~HasChildNodes.html) property.

``` c#
private bool ExpandToSelection(SfTreeView tree, TreeViewNodeCollection nodes, object model)
{
    foreach (var node in nodes)
    {
        if ((node.Content as FileManager).ItemName == (model as FileManager).ItemName)
        {
            var parent = node.ParentNode;
            while (parent != null)
            {
                tree.ExpandNode(parent);
                parent = parent.ParentNode;
            }
            return true;
        }
    }
    foreach (var node in nodes)
    {
        if (node.HasChildNodes)
        {
            if (ExpandToSelection(tree, node.ChildNodes, model))
                return true;
        }
    }
    return false;
}
```
**Output**

![TreeViewBringToView](https://github.com/SyncfusionExamples/bring-child-node-to-view-treeview-xamarin/blob/master/ScreenShot/TreeViewBringToView.gif)
