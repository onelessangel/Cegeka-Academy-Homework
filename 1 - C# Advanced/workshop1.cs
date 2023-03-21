		int number = 23;
		int copyOfNumber = number;
		Console.WriteLine($"Value of number: {number} and value of copy of number: {copyOfNumber}");
//########
		
		
		copyOfNumber = 40;
		Console.WriteLine($"Value of number: {number} and value of copy of number: {copyOfNumber}");
		
		void AlterValue(int input)
		{
		    input += 5;
		}
//########

		public class Employee
		{
			public string firstName;
		}
		
		Employee emp1 = new Employee();
		emp1.firstName = "John";
		Employee emp2 = emp1;
		emp2.firstName = "Jack";
		string check = emp1.firstName;// Ce valoare avem aici ?
		Console.WriteLine(check);
		
//########
		
		AlterEmployee(emp1, "Ted");		
		Console.WriteLine(emp1.firstName);
		
		void AlterEmployee(Employee emp, string newName)
		{
			emp.firstName = newName;
			/* TODO home work: 
			Ce se intampla daca rulez urmatorul cod:
			emp = new Employee();
			emp.firstName = newName; // ??? Cum fixez problema?
			*/
		}
//########
		string a = "Hello";
		string b;
		b = a;
		b += " wolrd";
		Console.WriteLine(b);
//########
		
		string someString = "some string";

		Console.WriteLine(someString);

		AlterString(someString); // pass the reference to the string on the heap

		Console.WriteLine(someString);

		void AlterString(string input)
		{
		   input += "you won't see this part"; // this actually creates a brand new string object on heap, and sets input to point at it (NOT someString)
		   // ^hovering on input even tells us this.
		}
//#########

		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("some text");
		stringBuilder.AppendLine("more text");
		stringBuilder.AppendLine("even more text");

		Console.WriteLine(stringBuilder.ToString()); // string is only created here
		AlterStringBuilder(stringBuilder);
		Console.WriteLine(stringBuilder.ToString()); // and another string created here.

		void AlterStringBuilder(StringBuilder sb)
		{
		   sb.AppendLine("Will you see this?");
		}
//#########
		int a = 0;
		int b = 10 / a;
		

		try
		{
			string input = Console.ReadLine();
			int a = int.Parse(input);
		}
		catch (FormatException ex)
		{
			Console.WriteLine(ex.Message);
			Console.WriteLine(ex.StackTrace);
		}
//#########
		catch (DivideByZeroException dbzex)
		{
		//Here we can handle the exception
		}
		
//#########
		catch(Exception ex)
		{
		//This will be invoked if another type of exception occurs
		}
//#########
		finally
		{
		//This will always execute
		}

// #############	 Main.cs

		      var employeeRepository = new GenericRepository<Employee>();
      AddEmployees(employeeRepository);
      GetEmployeeById(employeeRepository);

      var organizationRepository = new GenericRepository<Organization>();
      AddOrganizations(organizationRepository);

      Console.ReadLine();

// #############	


// #############	Program.cs

//* GetById

    private static void GetEmployeeById(GenericRepository<Employee> employeeRepository)
    {
      var employee = employeeRepository.GetById(2);
      Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
    }

    private static void AddEmployees(GenericRepository<Employee> employeeRepository)
    {
      employeeRepository.Add(new Employee { FirstName = "Jack" });
      employeeRepository.Add(new Employee { FirstName = "John" });
      employeeRepository.Add(new Employee { FirstName = "Ted" });
      employeeRepository.Save();
    }

    private static void AddOrganizations(GenericRepository<Organization> organizationRepository)
    {
      organizationRepository.Add(new Organization { Name = "Cegeka" });
      organizationRepository.Add(new Organization { Name = "Microsoft" });
      organizationRepository.Save();
    }


// #############	

        public void Remove(T item) {
            _items.Remove(item);
        }

		
        public T GetById(int id) {
            return _items.Single(item => item.Id == id);
        }
// #############	Delegates

            var input = Console.ReadLine();
            Console.WriteLine(input);

            var read = Console.ReadLine;
            var input = read();
            Console.WriteLine(input);

			var read = Console.ReadLine;
			var input = read();



        static string? ReadFromFile()
        {
            return File.ReadAllText("C:\\workspace\\CA\\dotnet\\message.txt");
        }

      	delegate void SayHello();
        SayHello delegateInstance = delegate() { Console.WriteLine("Hello Cegeka Academy!"); };
        delegateInstance.Invoke();
// #############	Delegates with parameter

        delegate void SayHello(string message);
            SayHello delegateInstance = delegate (string message) {
                if (string.IsNullOrWhiteSpace(message)) {
                    Console.WriteLine("Hello Cegeka Academy!");
                }
                else {
                    Console.WriteLine(message);
                }
            };
            delegateInstance.Invoke("Hello Igor!");


// #############	Lambda
// Lambda expression
(param1, param2) => param1 + param2;
SayHello lambdaExpression = message => Console.WriteLine("Hello");

// Lambda statement
(parameter1, parameter2) =>
{
    return parameter1 + parameter2;
};

            SayHello lambdaExpression = message =>
            {
                Console.WriteLine("Hello");
            };

// ### generic delegates

			delegate void Print<T>(T input);

            Print<string> printString = input => Console.WriteLine(input);
            Print<int> printNumber = (input) => Console.WriteLine(input);
			delegate PageSize Print<T, PageSize>(T input);

// home work 
// *Write a lambda expression that will return the next number after
        // the provided integer
        public static Func<int, int> GetNextNumber = ??? => ???;


// #### LINQ

// Some methods return a single element from the target sequence, such as First() or Last(). 
	// First country 
	// Last country
	//* First country that contains in name `ana`
	//* Single country that contains more than 1 billion
// Some methods return multiple elements out of the target sequence, such as Take(), Skip(), and Where().
	// Return countries that start with R
	// Return first 10 countries from the list
	// Return from 10 to 20 countries
	//* Return countries that have more than 20 mln 
// Some methods return the entire target sequence with the elements' order changed, such as Reverse() and OrderBy().
	// Return countries ordered by population
	// Return countries ordered by name length
	//* Return countries top 10 countries with less than 1 billion 
// Some methods return a single calculated value based on the input, such as Any(), Sum(), and Max().
	// sum of the first 10 countries
	// Min, max
	// Min population first 10 country
	// exist any country that less than 2 mln
// Some methods return a completely different sequence based on the target sequence, such as Select() and Cast().
 // return countries with number of population
 
// Home work => compute % from global population for each country.

//http://linq101.nilzorblog.com/linq101-lambda.php
      public class Country {
            public string Name { get; set; }
            public long Population { get; set; }
        }
        static List<Country> GetCountries() {
            var countries = new List<Country>()
            {
                new Country() {
                    Name = "China",
                    Population = 1440297825
                },
new Country() {
                    Name = "India",
                    Population = 1382345085
                },
new Country() {
                    Name = "United States",
                    Population = 331341050
                },
new Country() {
                    Name = "Indonesia",
                    Population = 274021604
                },
new Country() {
                    Name = "Pakistan",
                    Population = 221612785
                },
new Country() {
                    Name = "Brazil",
                    Population = 212821986
                },
new Country() {
                    Name = "Nigeria",
                    Population = 206984347
                },
new Country() {
                    Name = "Bangladesh",
                    Population = 164972348
                },
new Country() {
                    Name = "Russia",
                    Population = 145945524
                },
new Country() {
                    Name = "Mexico",
                    Population = 129166028
                },
new Country() {
                    Name = "Japan",
                    Population = 126407422
                },
new Country() {
                    Name = "Ethiopia",
                    Population = 115434444
                },
new Country() {
                    Name = "Philippines",
                    Population = 109830324
                },
new Country() {
                    Name = "Egypt",
                    Population = 102659126
                },
new Country() {
                    Name = "Vietnam",
                    Population = 97490013
                },
new Country() {
                    Name = "DR Congo",
                    Population = 90003954
                },
new Country() {
                    Name = "Turkey",
                    Population = 84495243
                },
new Country() {
                    Name = "Iran",
                    Population = 84176929
                },
new Country() {
                    Name = "Germany",
                    Population = 83830972
                },
new Country() {
                    Name = "Thailand",
                    Population = 69830779
                },
new Country() {
                    Name = "United Kingdom",
                    Population = 67948282
                },
new Country() {
                    Name = "France",
                    Population = 65298930
                },
new Country() {
                    Name = "Italy",
                    Population = 60446035
                },
new Country() {
                    Name = "Tanzania",
                    Population = 60012400
                },
new Country() {
                    Name = "South Africa",
                    Population = 59436725
                },
new Country() {
                    Name = "Myanmar",
                    Population = 54473253
                },
new Country() {
                    Name = "Kenya",
                    Population = 53968739
                },
new Country() {
                    Name = "South Korea",
                    Population = 51276977
                },
new Country() {
                    Name = "Colombia",
                    Population = 50976248
                },
new Country() {
                    Name = "Spain",
                    Population = 46757980
                },
new Country() {
                    Name = "Uganda",
                    Population = 45974931
                },
new Country() {
                    Name = "Argentina",
                    Population = 45267449
                },
new Country() {
                    Name = "Algeria",
                    Population = 43984569
                },
new Country() {
                    Name = "Sudan",
                    Population = 44019263
                },
new Country() {
                    Name = "Ukraine",
                    Population = 43686577
                },
new Country() {
                    Name = "Iraq",
                    Population = 40372771
                },
new Country() {
                    Name = "Afghanistan",
                    Population = 39074280
                },
new Country() {
                    Name = "Poland",
                    Population = 37839255
                },
new Country() {
                    Name = "Canada",
                    Population = 37799407
                },
new Country() {
                    Name = "Morocco",
                    Population = 36985624
                },
new Country() {
                    Name = "Saudi Arabia",
                    Population = 34905942
                },
new Country() {
                    Name = "Uzbekistan",
                    Population = 33551824
                },
new Country() {
                    Name = "Peru",
                    Population = 33050211
                },
new Country() {
                    Name = "Angola",
                    Population = 33032075
                },
new Country() {
                    Name = "Malaysia",
                    Population = 32436963
                },
new Country() {
                    Name = "Mozambique",
                    Population = 31398811
                },
new Country() {
                    Name = "Ghana",
                    Population = 31181428
                },
new Country() {
                    Name = "Yemen",
                    Population = 29935468
                },
new Country() {
                    Name = "Nepal",
                    Population = 29225196
                },
new Country() {
                    Name = "Venezuela",
                    Population = 28421581
                },
new Country() {
                    Name = "Madagascar",
                    Population = 27808395
                },
new Country() {
                    Name = "Cameroon",
                    Population = 26655083
                },
new Country() {
                    Name = "CÃ´te d'Ivoire",
                    Population = 26486282
                },
new Country() {
                    Name = "North Korea",
                    Population = 25798588
                },
new Country() {
                    Name = "Australia",
                    Population = 25550683
                },
new Country() {
                    Name = "Niger",
                    Population = 24346468
                },
new Country() {
                    Name = "Taiwan",
                    Population = 23824369
                },
new Country() {
                    Name = "Sri Lanka",
                    Population = 21428970
                },
new Country() {
                    Name = "Burkina Faso",
                    Population = 20997293
                },
new Country() {
                    Name = "Mali",
                    Population = 20346106
                },
new Country() {
                    Name = "Romania",
                    Population = 19214608
                },
new Country() {
                    Name = "Malawi",
                    Population = 19211425
                },
new Country() {
                    Name = "Chile",
                    Population = 19144605
                },
new Country() {
                    Name = "Kazakhstan",
                    Population = 18815231
                },
new Country() {
                    Name = "Zambia",
                    Population = 18468257
                },
new Country() {
                    Name = "Guatemala",
                    Population = 17971382
                },
new Country() {
                    Name = "Ecuador",
                    Population = 17688599
                },
new Country() {
                    Name = "Syria",
                    Population = 17571053
                },
new Country() {
                    Name = "Netherlands",
                    Population = 17141544
                },
new Country() {
                    Name = "Senegal",
                    Population = 16816539
                },
new Country() {
                    Name = "Cambodia",
                    Population = 16758448
                },
new Country() {
                    Name = "Chad",
                    Population = 16502877
                },
new Country() {
                    Name = "Somalia",
                    Population = 15965848
                },
new Country() {
                    Name = "Zimbabwe",
                    Population = 14899771
                },
new Country() {
                    Name = "Guinea",
                    Population = 13191279
                },
new Country() {
                    Name = "Rwanda",
                    Population = 13005303
                },
new Country() {
                    Name = "Benin",
                    Population = 12175480
                },
new Country() {
                    Name = "Burundi",
                    Population = 11948454
                },
new Country() {
                    Name = "Tunisia",
                    Population = 11839918
                },
new Country() {
                    Name = "Bolivia",
                    Population = 11700207
                },
new Country() {
                    Name = "Belgium",
                    Population = 11598451
                },
new Country() {
                    Name = "Haiti",
                    Population = 11426356
                },
new Country() {
                    Name = "Cuba",
                    Population = 11325391
                },
new Country() {
                    Name = "South Sudan",
                    Population = 11216250
                },
new Country() {
                    Name = "Dominican Republic",
                    Population = 10866667
                },
new Country() {
                    Name = "Czech Republic (Czechia)",
                    Population = 10712481
                },
new Country() {
                    Name = "Greece",
                    Population = 10413936
                },
new Country() {
                    Name = "Jordan",
                    Population = 10220604
                },
new Country() {
                    Name = "Portugal",
                    Population = 10191409
                },
new Country() {
                    Name = "Azerbaijan",
                    Population = 10154978
                },
new Country() {
                    Name = "Sweden",
                    Population = 10110233
                },
new Country() {
                    Name = "Honduras",
                    Population = 9931333
                },
new Country() {
                    Name = "United Arab Emirates",
                    Population = 9910892
                },
new Country() {
                    Name = "Hungary",
                    Population = 9655983
                },
new Country() {
                    Name = "Tajikistan",
                    Population = 9573310
                },
new Country() {
                    Name = "Belarus",
                    Population = 9448772
                },
new Country() {
                    Name = "Austria",
                    Population = 9015361
                },
new Country() {
                    Name = "Papua New Guinea",
                    Population = 8975531
                },
new Country() {
                    Name = "Serbia",
                    Population = 8731081
                },
new Country() {
                    Name = "Israel",
                    Population = 8678517
                },
new Country() {
                    Name = "Switzerland",
                    Population = 8665615
                },
new Country() {
                    Name = "Togo",
                    Population = 8310934
                },
new Country() {
                    Name = "Sierra Leone",
                    Population = 8004158
                },
new Country() {
                    Name = "Hong Kong",
                    Population = 7507523
                },
new Country() {
                    Name = "Laos",
                    Population = 7293542
                },
new Country() {
                    Name = "Paraguay",
                    Population = 7147553
                },
new Country() {
                    Name = "Bulgaria",
                    Population = 6939018
                },
new Country() {
                    Name = "Libya",
                    Population = 6887247
                },
new Country() {
                    Name = "Lebanon",
                    Population = 6819976
                },
new Country() {
                    Name = "Nicaragua",
                    Population = 6638075
                },
new Country() {
                    Name = "Kyrgyzstan",
                    Population = 6542426
                },
new Country() {
                    Name = "El Salvador",
                    Population = 6491923
                },
new Country() {
                    Name = "Turkmenistan",
                    Population = 6046292
                },
new Country() {
                    Name = "Singapore",
                    Population = 5858322
                },
new Country() {
                    Name = "Denmark",
                    Population = 5795780
                },
new Country() {
                    Name = "Finland",
                    Population = 5542237
                },
new Country() {
                    Name = "Congo",
                    Population = 5540555
                },
new Country() {
                    Name = "Slovakia",
                    Population = 5460109
                },
new Country() {
                    Name = "Norway",
                    Population = 5428594
                },
new Country() {
                    Name = "Oman",
                    Population = 5128058
                },
new Country() {
                    Name = "State of Palestine",
                    Population = 5121112
                },
new Country() {
                    Name = "Costa Rica",
                    Population = 5102158
                },
new Country() {
                    Name = "Liberia",
                    Population = 5077411
                },
new Country() {
                    Name = "Ireland",
                    Population = 4947267
                },
new Country() {
                    Name = "Central African Republic",
                    Population = 4843954
                },
new Country() {
                    Name = "New Zealand",
                    Population = 4829021
                },
new Country() {
                    Name = "Mauritania",
                    Population = 4669775
                },
new Country() {
                    Name = "Panama",
                    Population = 4326296
                },
new Country() {
                    Name = "Kuwait",
                    Population = 4281320
                },
new Country() {
                    Name = "Croatia",
                    Population = 4100719
                },
new Country() {
                    Name = "Moldova",
                    Population = 4032294
                },
new Country() {
                    Name = "Georgia",
                    Population = 3987805
                },
new Country() {
                    Name = "Eritrea",
                    Population = 3554797
                },
new Country() {
                    Name = "Uruguay",
                    Population = 3475842
                },
new Country() {
                    Name = "Bosnia and Herzegovina",
                    Population = 3277152
                },
new Country() {
                    Name = "Mongolia",
                    Population = 3287242
                },
new Country() {
                    Name = "Armenia",
                    Population = 2964219
                },
new Country() {
                    Name = "Jamaica",
                    Population = 2963429
                },
new Country() {
                    Name = "Qatar",
                    Population = 2889284
                },
new Country() {
                    Name = "Albania",
                    Population = 2877239
                },
new Country() {
                    Name = "Puerto Rico",
                    Population = 2846860
                },
new Country() {
                    Name = "Lithuania",
                    Population = 2715340
                },
new Country() {
                    Name = "Namibia",
                    Population = 2548663
                },
new Country() {
                    Name = "Gambia",
                    Population = 2427782
                },
new Country() {
                    Name = "Botswana",
                    Population = 2359585
                },
new Country() {
                    Name = "Gabon",
                    Population = 2234448
                },
new Country() {
                    Name = "Lesotho",
                    Population = 2145194
                },
new Country() {
                    Name = "North Macedonia",
                    Population = 2083359
                },
new Country() {
                    Name = "Slovenia",
                    Population = 2078989
                },
new Country() {
                    Name = "Guinea-Bissau",
                    Population = 1975718
                },
new Country() {
                    Name = "Latvia",
                    Population = 1882408
                },
new Country() {
                    Name = "Bahrain",
                    Population = 1711057
                },
new Country() {
                    Name = "Equatorial Guinea",
                    Population = 1410419
                },
new Country() {
                    Name = "Trinidad and Tobago",
                    Population = 1400283
                },
new Country() {
                    Name = "Estonia",
                    Population = 1326693
                },
new Country() {
                    Name = "Timor-Leste",
                    Population = 1322667
                },
new Country() {
                    Name = "Mauritius",
                    Population = 1272140
                },
new Country() {
                    Name = "Cyprus",
                    Population = 1208886
                },
new Country() {
                    Name = "Eswatini",
                    Population = 1162233
                },
new Country() {
                    Name = "Djibouti",
                    Population = 990447
                },
new Country() {
                    Name = "Fiji",
                    Population = 897573
                },
new Country() {
                    Name = "RÃ©union",
                    Population = 896422
                },
new Country() {
                    Name = "Comoros",
                    Population = 872695
                },
new Country() {
                    Name = "Guyana",
                    Population = 787215
                },
new Country() {
                    Name = "Bhutan",
                    Population = 773069
                },
new Country() {
                    Name = "Solomon Islands",
                    Population = 689671
                },
new Country() {
                    Name = "Macao",
                    Population = 650846
                },
new Country() {
                    Name = "Montenegro",
                    Population = 628080
                },
new Country() {
                    Name = "Luxembourg",
                    Population = 627704
                },
new Country() {
                    Name = "Western Sahara",
                    Population = 599769
                },
new Country() {
                    Name = "Suriname",
                    Population = 587541
                },
new Country() {
                    Name = "Cabo Verde",
                    Population = 557026
                },
new Country() {
                    Name = "Maldives",
                    Population = 542151
                },
new Country() {
                    Name = "Malta",
                    Population = 441750
                },
new Country() {
                    Name = "Brunei",
                    Population = 438202
                },
new Country() {
                    Name = "Guadeloupe",
                    Population = 400136
                },
new Country() {
                    Name = "Belize",
                    Population = 398845
                },
new Country() {
                    Name = "Bahamas",
                    Population = 393893
                },
new Country() {
                    Name = "Martinique",
                    Population = 375213
                },
new Country() {
                    Name = "Iceland",
                    Population = 341628
                },
new Country() {
                    Name = "Vanuatu",
                    Population = 308337
                },
new Country() {
                    Name = "French Guiana",
                    Population = 299958
                },
new Country() {
                    Name = "Barbados",
                    Population = 287437
                },
new Country() {
                    Name = "New Caledonia",
                    Population = 285972
                },
new Country() {
                    Name = "French Polynesia",
                    Population = 281191
                },
new Country() {
                    Name = "Mayotte",
                    Population = 273905
                },
new Country() {
                    Name = "Sao Tome & Principe",
                    Population = 219844
                },
new Country() {
                    Name = "Samoa",
                    Population = 198643
                },
new Country() {
                    Name = "Saint Lucia",
                    Population = 183774
                },
new Country() {
                    Name = "Channel Islands",
                    Population = 174140
                },
new Country() {
                    Name = "Guam",
                    Population = 169031
                },
new Country() {
                    Name = "CuraÃ§ao",
                    Population = 164211
                },
new Country() {
                    Name = "Kiribati",
                    Population = 119760
                },
new Country() {
                    Name = "Micronesia",
                    Population = 115231
                },
new Country() {
                    Name = "Grenada",
                    Population = 112614
                },
new Country() {
                    Name = "St. Vincent & Grenadines",
                    Population = 111002
                },
new Country() {
                    Name = "Aruba",
                    Population = 106845
                },
new Country() {
                    Name = "Tonga",
                    Population = 105901
                },
new Country() {
                    Name = "U.S. Virgin Islands",
                    Population = 104398
                },
new Country() {
                    Name = "Seychelles",
                    Population = 98453
                },
new Country() {
                    Name = "Antigua and Barbuda",
                    Population = 98069
                },
new Country() {
                    Name = "Isle of Man",
                    Population = 85112
                },
new Country() {
                    Name = "Andorra",
                    Population = 77287
                },
new Country() {
                    Name = "Dominica",
                    Population = 72017
                },
new Country() {
                    Name = "Cayman Islands",
                    Population = 65854
                },
new Country() {
                    Name = "Bermuda",
                    Population = 62237
                },
new Country() {
                    Name = "Marshall Islands",
                    Population = 59259
                },
new Country() {
                    Name = "Northern Mariana Islands",
                    Population = 57619
                },
new Country() {
                    Name = "Greenland",
                    Population = 56787
                },
new Country() {
                    Name = "American Samoa",
                    Population = 55169
                },
new Country() {
                    Name = "Saint Kitts & Nevis",
                    Population = 53264
                },
new Country() {
                    Name = "Faeroe Islands",
                    Population = 48896
                },
new Country() {
                    Name = "Sint Maarten",
                    Population = 42960
                },
new Country() {
                    Name = "Monaco",
                    Population = 39290
                },
new Country() {
                    Name = "Turks and Caicos",
                    Population = 38806
                },
new Country() {
                    Name = "Saint Martin",
                    Population = 38778
                },
new Country() {
                    Name = "Liechtenstein",
                    Population = 38147
                },
new Country() {
                    Name = "San Marino",
                    Population = 33944
                },
new Country() {
                    Name = "Gibraltar",
                    Population = 33689
                },
new Country() {
                    Name = "British Virgin Islands",
                    Population = 30266
                },
new Country() {
                    Name = "Caribbean Netherlands",
                    Population = 26265
                },
new Country() {
                    Name = "Palau",
                    Population = 18109
                },
new Country() {
                    Name = "Cook Islands",
                    Population = 17567
                },
new Country() {
                    Name = "Anguilla",
                    Population = 15026
                },
new Country() {
                    Name = "Tuvalu",
                    Population = 11817
                },
new Country() {
                    Name = "Wallis & Futuna",
                    Population = 11203
                },
new Country() {
                    Name = "Nauru",
                    Population = 10836
                },
new Country() {
                    Name = "Saint Barthelemy",
                    Population = 9882
                },
new Country() {
                    Name = "Saint Helena",
                    Population = 6080
                },
new Country() {
                    Name = "Saint Pierre & Miquelon",
                    Population = 5789
                },
new Country() {
                    Name = "Montserrat",
                    Population = 4993
                },
new Country() {
                    Name = "Falkland Islands",
                    Population = 3497
                },
new Country() {
                    Name = "Niue",
                    Population = 1628
                },
new Country() {
                    Name = "Tokelau",
                    Population = 1360
                },
new Country() {
                    Name = "Holy See",
                    Population = 801
                }
            };
            return countries;
        }


        

        static void GetDataFromFile()
        {
            string text = System.IO.File.ReadAllText(@"C:\workspace\CA\dotnet\message.txt");

            // Display the file contents to the console. Variable text is a string.
            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
        }