using System;


//Program Description : Program to show the Containment relationship (Composition)

namespace Samples
{
	public class Item
	{
		#region " Private Class Members "

		private string _itemCode;
		private float _itemCost;
		private int _itemQty;
		private bool _isDeleted;

		#endregion
        	
		#region " Public Properties "

		  public string ItemCode
		  {
			  get
			  {
				  return _itemCode;
			  }
			  set
			  {
				  if (value.Trim() == "")
					  throw new Exception("Item Code cannot be blank.");

				  _itemCode = value;
			  }
		  }

		  public float ItemCost
		  {
			  get
			  {
				  return _itemCost;
			  }
			  set
			  {
				  if( value < 0)
					  throw new Exception("Item Cost cannot be less than or equal to Zero");

				  _itemCost = value;
			  }
		  }

		  public int ItemQty
		  {
			  get
			  {
				  return _itemQty;
			  }
			  set
			  {
				  if( value < 0)
					  throw new Exception("Item Qty cannot be less than or equal to Zero");

				  _itemQty = value;                    
			  }
		  }

		  public bool IsDeleted
		  {
			  get
			  {
				  return _isDeleted;
			  }
			  set
			  {
				  _isDeleted = value;
			  }
		}

		#endregion
	}

	public class ItemCol
	{
		  #region " Private Class Members "

		  private Item[] _items;

		  #endregion

		  #region " Constructor "

		  public ItemCol()
		  {               
			  _items = new Item[10];

			  for(int i = 0; i < 10; i++)
				  _items[i] = new Item();
		  }

		  #endregion

		  #region " Public Properties "

		  // Indexer Property, which helps to work with ForEach loop

		  public Item this[int index]
		  {
			  get
			  {
				  if( index >= 0 || index <10)
					  return _items[index];
				  else
					  throw new Exception("Array out of Bounds Exception");
			  }
			  set
			  {
				  if( index >= 0 || index <10)
					  _items[index] = value;
				  else
					  throw new Exception("Array out of Bounds Exception");
			  }
		  }

		  #endregion
	}

	public class TestApp
	{
		private ItemCol _iCol = new ItemCol();
		private int _count;

		public int Count
		{
			get
			{
				return _count;
			}
			set 
			{
				_count = value;
			}
		}

		public ItemCol ICol
		{
			get
			{
				return _iCol;
			}
			set
			{
				_iCol = value;
			}
		}
		
		public void AddItem()
		{
			Console.WriteLine("Enter Item Code : ");			
			ICol[Count].ItemCode = Console.ReadLine().ToString();

			Console.WriteLine("Enter Item Cost : ");
			ICol[Count].ItemCost = float.Parse(Console.ReadLine());

			Console.WriteLine("Enter Item Qty : ");
			ICol[Count].ItemQty = int.Parse(Console.ReadLine());

			Count++;	
		}

		public void DisplayItems()
		{	
			float total = 0;

			for(int i = 0; i < Count ; i++)
			{
				Console.WriteLine("Item Code : {0}",ICol[i].ItemCode);
				Console.WriteLine("Item Cost : {0}",ICol[i].ItemCost.ToString());
				Console.WriteLine("Item Qty : {0}",ICol[i].ItemQty.ToString());

				total += (ICol[i].ItemCost * ICol[i].ItemQty);
			}
			
			Console.WriteLine("Total Amt to Paid : {0}",total.ToString());
		}

		public void DeleteItem()
		{
			string itemCode;
			bool isItemFound = false;
			string confirmation;

			Console.WriteLine("Enter the Item Code to delete the Item : ");
			itemCode = Console.ReadLine().ToString();

			for(int i = 0; i < Count ; i++)
			{
				if (ICol[i].ItemCode.Trim() == itemCode.Trim())
				{		
					isItemFound = true;
					Console.WriteLine("Do you want to delete {0} Item? (Y/N) : ",ICol[i].ItemCode);
					confirmation = Console.ReadLine().ToString();

					if(confirmation.Trim().ToUpper() == "Y")
						ICol[i].IsDeleted = true;
				}
			}

			if(isItemFound == false)
				Console.WriteLine("No Such Item Found!");
		}

		public void Menu()
		{
			Console.WriteLine("1. Add Item : ");
			Console.WriteLine("2. Display All Items : ");
			Console.WriteLine("3. Delete Item : ");
			Console.WriteLine("4. Quit : ");
			Console.WriteLine("Enter your Choice : ");
		}

		public static void Main(string[] args)
		{
			TestApp test = new TestApp();
			string choice;

			do
			{
				test.Menu();
				choice = Console.ReadLine().ToString();

				switch(choice)
				{
					case "1" : test.AddItem();
						   break;
					case "2" : test.DisplayItems();
						   break;
					case "3" : test.DeleteItem();
						   break;
					case "4":  return;													}
			}while(true);
		}
	}
}

// How to Compile : csc Item.cs
// How to Run : Item or Item.exe