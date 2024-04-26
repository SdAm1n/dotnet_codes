# Winforms Setup

## Setting up a form

- Appearance
  - BackColor
  - BackgroundImage
  - BackgroundImageLayout
- Window Style
  - MaximizeBox
  - MinimizeBox
- Size
  - Start Position
- Font
  - Text
  - Font
  - ForeColor
- Controls
  - Name
  - Text
  - TabIndex

## ListboxItem

- Items : to add items to the listbox only at design time
- Selection Mode: Single, MultiSimple, MultiExtended defines how many items can be selected at a time
- To add item: `listbox1.Items.Add("Item1");`
- Focus on textbox: `textbox1.Focus();`
- Count of items: `listbox1.Items.Count;`
- Sort items: `listbox1.Sorted = true;`
- Remove specific item: `listbox1.Items.Remove(listbox1.SelectedItem);` select the item first. or remove by index `listbox1.Items.RemoveAt(listbox1.SelectedIndex);`
- Remove all items: `listbox1.Items.Clear();`

## Combobox

- Items: to add items to the combobox only at design time.
- DropDownStyle: DropDownList (can not edit), DropDown (can edit), Simple (List box is open) defines the style of the combobox.
- Properties
  - AutoCompleteCustomSource: to add items to the combobox at runtime.
  - AutoCompleteMode: Suggest, Append, SuggestAppend
  - AutoCompleteSource: CustomSource, ListItems, HistoryList
  - Do both AutoCompleteMode and AutoCompleteSource to get the autocomplete feature. (use suggest and ListItems)
- To add item: `combobox1.Items.Add(textbox1.Text);`
- clear textbox: `textbox1.Clear();`
- Selected Index Changed: `combobox1.SelectedItem;`. convert to string if needed.
- Find already existing item: `combobox1.Items.Contains(textbox1.Text);`

## Link Label

- To visit a link: `System.Diagnostics.Process.Start("https://www.google.com");`
- Go to another form:

```csharp
Form2 form2 = new Form2();
form2.Show();
```

- Remove Underline of Link Label

```csharp
// Add this to Form_Load Event
this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
```

## Pass Data between Forms

- Create static variables in one form and reference them in another form.

## Radio Button

- check if radio button is checked: `radiobutton1.Checked`. it returns boolean value.
- User group box to group radio buttons.
- change form color: `this.BackColor = System.Drawing.Color.Red;`

## Error Provider

- Add error provider to the form.
- Set error message: `errorProvider1.SetError(this.textbox1, "Please enter a value");`
- clear error message: `errorProvider1.Clear();`
- set icon: `errorProvider1.Icon = Properties.Resources.IconName;`

## Email Validation

- Check the EmailValidation Project

## Password Validation

- same as email validation but with different regex. `(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$`
- to hide password set property `UseSystemPasswordChar` to true.
- To change `.` to `*` set `PasswordChar` property to*.

## Textbox Validation

### Digit Validation

```csharp
private void textbox1_KeyPress(object sender, KeyPressEventArgs e)
{
    char c = e.KeyChar;
    if (!char.IsDigit(c) && c != 8) // c=8 is backspace
    {
        e.Handled = true;
    }
    else 
    {
        e.Handled = false;
    }
}
```

- Set property `MaxLength` to limit the number of characters.

### Letter Validation

```csharp
private void textbox1_KeyPress(object sender, KeyPressEventArgs e)
{
    char c = e.KeyChar;
    if (!char.IsLetter(c) && c != 8 && c != 32) // c=8 is backspace and c=32 is space
    {
        e.Handled = true;
    }
    else 
    {
        e.Handled = false;
    }
}
```

### Both

```csharp
private void textbox1_KeyPress(object sender, KeyPressEventArgs e)
{
    char c = e.KeyChar;
    if (!char.IsLetterOrDigit(c) && c != 8 && c != 32) // c=8 is backspace and c=32 is space
    {
        e.Handled = true;
    }
    else 
    {
        e.Handled = false;
    }
}
```
