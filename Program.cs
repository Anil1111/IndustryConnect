using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprilTA
{
    class Program
    {
        static void Main(string[] args)
        {

            /**Test case 1: Check if user is able to login with valid credentials **/

            //open a new chrome browser
            IWebDriver driver = new ChromeDriver(@"C:\Dev\Tools");

            //launch browser 
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2fTimeMaterial");
            driver.Manage().Window.Maximize();


            //Enter username
            IWebElement userName = driver.FindElement(By.Id("UserName"));
            userName.SendKeys("hari");


            //Enter password
            IWebElement passWord = driver.FindElement(By.Id("Password"));
            passWord.SendKeys("123123");


            //Click Login button
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();


            //Verify Home page is displayed 
            IWebElement homePage = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if (homePage.Text == "Hello hari!")
            {
                Console.WriteLine("We are in Home page, Test Passed");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }

            /** Test case 2: Check whether an user is able to create new time and material record successfully**/

            //Go to Time & Material Page  
            IWebElement adminPage = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            adminPage.Click();

            //Verify  Time & Material Page is displayed
            IWebElement timeandMaterialPage = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]"));
            timeandMaterialPage.Click();
            if (driver.FindElement(By.XPath("//*[@id='container']/p/a")).Displayed)
            {
                Console.WriteLine("We are in Time & Material Page, Test Passed");
            }
            else
            {
                Console.WriteLine("We are not in Time & Material Page, Test Failed");
            }

            //Click "Create New" button 
            IWebElement createnewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createnewButton.Click();

            //Click dropdown box from "TypeCode"
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            typeCodeDropdown.Click();
            System.Threading.Thread.Sleep(1000);

            //Click "Material" option from "Time" in "TypeCode" dropdown
            IWebElement timeCodeLink = driver.FindElement(By.XPath("/html[1]/body[1]/div[5]/div[1]/ul[1]/li[2]"));
            timeCodeLink.Click();

            //Enter valid data in "Code" text field 
            IWebElement codeField = driver.FindElement(By.XPath("//*[@id='Code']"));
            codeField.SendKeys("Test123");

            //Enter valid data in "Description" text field 
            IWebElement descriptionField = driver.FindElement(By.XPath("//*[@id='Description']"));
            descriptionField.SendKeys("Testing to see");

            //Enter valid data in "Price per unit" text field 
            IWebElement priceField = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceField.SendKeys("199999999");

            /** click "Select files" and upload any files from the desktop
            IWebElement selectFilesButton = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/div/div"));
            selectFilesButton.Click();**/

            //Click "Save" button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            //Verify Home page is displayed once the "Save" button is clicked 
            IWebElement homePageNew = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if (homePageNew.Text == "Hello hari!")
            {
                Console.WriteLine("We are in Home page, Test Passed");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }

            System.Threading.Thread.Sleep(1000);

            /**Test case 3: Check whether an user is able to edit an existing time and material record**/

            //Go to Edit button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]"));
            editButton.Click();

            //Verify Edit page is Displayed 
            IWebElement editPage = driver.FindElement(By.XPath("//*[@id='container']/h2"));
            if (editPage.Text == "Time and Materials")
            {
                Console.WriteLine("We are in Edit page, Test Passed");
            }
            else
            {
                Console.WriteLine("We are not in Edit page, Test Failed");
            }

            //Click dropdown box from "TypeCode"
            IWebElement typeCodeDropdownTwo = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            typeCodeDropdownTwo.Click();
            System.Threading.Thread.Sleep(1000);

            //Click "Material" option from "Time" in "TypeCode" dropdown
            IWebElement timeCodeLinkTwo = driver.FindElement(By.XPath("/html[1]/body[1]/div[5]/div[1]/ul[1]/li[1]"));
            timeCodeLinkTwo.Click();

            //Enter valid data in "Code" text field 
            IWebElement codeFieldEdit = driver.FindElement(By.XPath("//*[@id='Code']"));
            codeFieldEdit.Clear();
            codeFieldEdit.SendKeys("Test to see");

            //Enter valid data in "Description" text field 
            IWebElement descriptionFieldEdit = driver.FindElement(By.XPath("//*[@id='Description']"));
            descriptionFieldEdit.Clear();
            descriptionFieldEdit.SendKeys("Testing to see if edit page works");

            //Enter valid data in "Price per unit" text field 
            System.Threading.Thread.Sleep(1000);
            IWebElement priceFieldEdit = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span"));
            System.Threading.Thread.Sleep(1000);
            priceFieldEdit.Click();
            System.Threading.Thread.Sleep(1000);
            IWebElement priceFieldEditData = driver.FindElement(By.XPath("//*[@id='Price']"));
            System.Threading.Thread.Sleep(1000);
            priceFieldEditData.Clear();
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
            priceFieldEditData.SendKeys("19999999");

            //Click "Save" button in "Edit" page
            IWebElement saveButtonEdit = driver.FindElement(By.Id("SaveButton"));
            saveButtonEdit.Click();

            //Verify Home page is displayed once the "Save" button is clicked in the "Edit" page
            IWebElement homePageEdit = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if (homePageEdit.Text == "Hello hari!")
            {
                Console.WriteLine("We are in Home page after Editing the records, Test Passed");
            }
            else
            {
                Console.WriteLine("We are not in Home page after Editing the records, Test Failed");
            }

            //Verify edited record is updated to time and material record succesfully 
            var elemTable = driver.FindElement(By.XPath("//*[@id='tmsGrid']"));
            



            IWebElement firtRowEdit = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]"));
            if (firtRowEdit.Text == "Testing to see if edit page works")
            {
                Console.WriteLine("Edited record is updated to time and material record succesfully, Test Passed ");
            }
            else
            {
                Console.WriteLine("Edited record is not updated to time and material record succesfully, Test Failed ");
            }






            /** Test case 4: Check whether an user is able to delete an existing time and material record successfully**/


            /**The Code field should not be more than 20 character**/

            //Close the browser 
            driver.Close();

        }
    }
}
  class Program
    {
        static void Main(string[] args)
        {

            /**Test case 1: Check if user is able to login with valid credentials **/

            //open a new chrome browser
            IWebDriver driver = new ChromeDriver(@"C:\Dev\Tools");

            //launch browser 
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2fTimeMaterial");
            driver.Manage().Window.Maximize();


            //Enter username
            IWebElement userName = driver.FindElement(By.Id("UserName"));
            userName.SendKeys("hari");


            //Enter password
            IWebElement passWord = driver.FindElement(By.Id("Password"));
            passWord.SendKeys("123123");


            //Click Login button
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();


            //Verify Home page is displayed 
            IWebElement homePage = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if (homePage.Text == "Hello hari!")
            {
                Console.WriteLine("We are in Home page, Test Passed");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }

            /** Test case 2: Check whether an user is able to create new time and material record successfully**/

            //Go to Time & Material Page  
            IWebElement adminPage = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            adminPage.Click();

            //Verify  Time & Material Page is displayed
            IWebElement timeandMaterialPage = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]"));
            timeandMaterialPage.Click();
            if (driver.FindElement(By.XPath("//*[@id='container']/p/a")).Displayed)
            {
                Console.WriteLine("We are in Time & Material Page, Test Passed");
            }
            else
            {
                Console.WriteLine("We are not in Time & Material Page, Test Failed");
            }

            //Click "Create New" button 
            IWebElement createnewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createnewButton.Click();

            //Click dropdown box from "TypeCode"
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            typeCodeDropdown.Click();
            System.Threading.Thread.Sleep(1000);

            //Click "Material" option from "Time" in "TypeCode" dropdown
            IWebElement timeCodeLink = driver.FindElement(By.XPath("/html[1]/body[1]/div[5]/div[1]/ul[1]/li[2]"));
            timeCodeLink.Click();

            //Enter valid data in "Code" text field 
            IWebElement codeField = driver.FindElement(By.XPath("//*[@id='Code']"));
            codeField.SendKeys("Test123");

            //Enter valid data in "Description" text field 
            IWebElement descriptionField = driver.FindElement(By.XPath("//*[@id='Description']"));
            descriptionField.SendKeys("Testing to see");

            //Enter valid data in "Price per unit" text field 
            IWebElement priceField = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceField.SendKeys("199999999");

            /** click "Select files" and upload any files from the desktop
            IWebElement selectFilesButton = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/div/div"));
            selectFilesButton.Click();**/

            //Click "Save" button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            //Verify Home page is displayed once the "Save" button is clicked 
            IWebElement homePageNew = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if (homePageNew.Text == "Hello hari!")
            {
                Console.WriteLine("We are in Home page, Test Passed");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }

            System.Threading.Thread.Sleep(1000);

            /**Test case 3: Check whether an user is able to edit an existing time and material record**/

            //Go to Edit button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]"));
            editButton.Click();

            //Verify Edit page is Displayed 
            IWebElement editPage = driver.FindElement(By.XPath("//*[@id='container']/h2"));
            if (editPage.Text == "Time and Materials")
            {
                Console.WriteLine("We are in Edit page, Test Passed");
            }
            else
            {
                Console.WriteLine("We are not in Edit page, Test Failed");
            }

            //Click dropdown box from "TypeCode"
            IWebElement typeCodeDropdownTwo = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            typeCodeDropdownTwo.Click();
            System.Threading.Thread.Sleep(1000);

            //Click "Material" option from "Time" in "TypeCode" dropdown
            IWebElement timeCodeLinkTwo = driver.FindElement(By.XPath("/html[1]/body[1]/div[5]/div[1]/ul[1]/li[1]"));
            timeCodeLinkTwo.Click();

            //Enter valid data in "Code" text field 
            IWebElement codeFieldEdit = driver.FindElement(By.XPath("//*[@id='Code']"));
            codeFieldEdit.Clear();
            codeFieldEdit.SendKeys("Test to see");

            //Enter valid data in "Description" text field 
            IWebElement descriptionFieldEdit = driver.FindElement(By.XPath("//*[@id='Description']"));
            descriptionFieldEdit.Clear();
            descriptionFieldEdit.SendKeys("Testing to see if edit page works");

            //Enter valid data in "Price per unit" text field 
            System.Threading.Thread.Sleep(1000);
            IWebElement priceFieldEdit = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span"));
            System.Threading.Thread.Sleep(1000);
            priceFieldEdit.Click();
            System.Threading.Thread.Sleep(1000);
            IWebElement priceFieldEditData = driver.FindElement(By.XPath("//*[@id='Price']"));
            System.Threading.Thread.Sleep(1000);
            priceFieldEditData.Clear();
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
            priceFieldEditData.SendKeys("19999999");

            //Click "Save" button in "Edit" page
            IWebElement saveButtonEdit = driver.FindElement(By.Id("SaveButton"));
            saveButtonEdit.Click();

            //Verify Home page is displayed once the "Save" button is clicked in the "Edit" page
            IWebElement homePageEdit = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if (homePageEdit.Text == "Hello hari!")
            {
                Console.WriteLine("We are in Home page after Editing the records, Test Passed");
            }
            else
            {
                Console.WriteLine("We are not in Home page after Editing the records, Test Failed");
            }

            //Verify edited record is updated to time and material record succesfully 
            var elemTable = driver.FindElement(By.XPath("//*[@id='tmsGrid']"));
            List<IWebElement> listTrElement = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));
            IWebElement row = listTrElement.Where(item => item.Text.Contains("$19,999,999.00"));


            IWebElement firtRowEdit = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]"));
            if (firtRowEdit.Text == "Testing to see if edit page works")
            {
                Console.WriteLine("Edited record is updated to time and material record succesfully, Test Passed ");
            }
            else
            {
                Console.WriteLine("Edited record is not updated to time and material record succesfully, Test Failed ");
            }



            /** Test case 4: Check whether an user is able to delete an existing time and material record successfully**/


            /**The Code field should not be more than 20 character**/

            //Close the browser 
            driver.Close();

        }
    }
}


