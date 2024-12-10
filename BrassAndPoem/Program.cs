//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
using System.Data.Common;

List<Product> products = new List<Product>
{
    new Product { Name = "Laptop", Price = 999.99m, ProductTypeId = 1 },
    new Product { Name = "T-Shirt", Price = 19.99m, ProductTypeId = 2 },
    new Product { Name = "Smartphone", Price = 799.99m, ProductTypeId = 1 },
    new Product { Name = "Jeans", Price = 39.99m, ProductTypeId = 2 },
    new Product { Name = "Shirts", Price = 9.99m, ProductTypeId = 2 }
};


//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>
{
    new ProductType {Title = "Electronics", Id = 1},
    new ProductType {Title = "Clothing", Id = 2}
};

//put your greeting here
Console.WriteLine("Welcome to the Product Management Application!");
Console.WriteLine("Please choose an option from the menu below:");

        // Implement your loop here
        bool exit = false;

        while (!exit)
        {
            // Display the menu by calling DisplayMenu
            DisplayMenu();

            // Get user choice
            Console.Write("Enter your choice (1-5): ");
            string userInput = Console.ReadLine();
            int choice;

            // Check if the user input is a valid integer
            if (int.TryParse(userInput, out choice))
            {
                switch (choice)
                {
                    case 1:
                        DisplayAllProducts(products, productTypes);
                        break;

                    case 2:
                        DeleteProduct(products, productTypes);
                        break;

                    case 3:
                        AddProduct(products, productTypes);
                        break;

                    case 4:
                        UpdateProduct(products, productTypes);
                        break;

                    case 5:
                        // Exit the program
                        Console.WriteLine("Exiting the application. Thank you for using the Product Management App!");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
        }
    

    // Function to display the menu options
    static void DisplayMenu()
    {
        Console.WriteLine("1. Display all products");
        Console.WriteLine("2. Delete a product");
        Console.WriteLine("3. Add a new product");
        Console.WriteLine("4. Update product properties");
        Console.WriteLine("5. Exit");
    }



void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    int count = 1;  // Initialize count outside of the loop

    foreach (var product in products)
    {
        // Use LINQ to find the matching product type based on the ProductTypeId
        var productType = productTypes.FirstOrDefault(type => type.Id == product.ProductTypeId);

        // If a matching product type is found, get its title; otherwise, show "Unknown Type"
        string productTypeTitle = productType != null ? productType.Title : "Unknown Type";

        // Display product details including its type
        Console.WriteLine($"{count}. {product.Name}: {product.Price} ({productTypeTitle})");
        ++count;  // Increment count after printing each product
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
    Console.WriteLine("Select which product to delete: ");
    int productIndex = (int.Parse(Console.ReadLine()) -1);

    // Remove the selected product
    var product = products[productIndex];
    products.RemoveAt(productIndex);

    Console.WriteLine($"Product '{product.Name}' deleted successfully.");
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("\nEnter product details:");

    Console.Write("Name: ");
    string name = Console.ReadLine();

    Console.Write("Price: ");
    decimal price = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Select a product type:");
    for (int index = 0; index < productTypes.Count; index++)
    {
        Console.WriteLine($"{index + 1}. {productTypes[index].Title}");
    }

    Console.Write("Product Type: ");
    int productTypeId = int.Parse(Console.ReadLine());

    products.Add(new Product{Name = name, Price = price, ProductTypeId = productTypeId});
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    // Display all products to the user
    DisplayAllProducts(products, productTypes);
    Console.Write("Please select a product to update (enter the number): ");
    
    // Get the user's product selection and adjust for 0-based index
    int selection;
    if (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > products.Count)
    {
        Console.WriteLine("Invalid product selection.");
        return;
    }

    // Adjust the selection to 0-based index
    selection -= 1;

    // Retrieve the selected product based on the user's choice
    Product product = products[selection];

    // Display the current product details to the user
    Console.WriteLine($"Updating product: {product.Name}");

    // Allow the user to update the product name (handle empty input)
    Console.Write("New Name (leave empty to keep the current name): ");
    string newName = Console.ReadLine();
    if (!string.IsNullOrEmpty(newName))
    {
        product.Name = newName;
    }

    // Allow the user to select a new product type
    Console.WriteLine("Select a new product type:");
    for (int index = 0; index < productTypes.Count; index++)
    {
        Console.WriteLine($"{index + 1}. {productTypes[index].Title}");  // Display product type titles
    }

    // Get the new product type selection and adjust for 1-based input
    int productTypeId;
    if (!int.TryParse(Console.ReadLine(), out productTypeId) || productTypeId < 1 || productTypeId > productTypes.Count)
    {
        Console.WriteLine("Invalid product type selection.");
        return;
    }

    // Update the product's type if the selection is valid
    product.ProductTypeId = productTypeId;

    // Display success message
    Console.WriteLine("Product updated successfully!");
}


// don't move or change this!
public partial class Program { }
