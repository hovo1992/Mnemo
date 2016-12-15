using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace MemoryGameProject
{
	class Account
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public static string RegistrID { get; set; }

		public string TagsForFields(XmlDocument xmlDoc)
		{
			XmlElement account = xmlDoc.CreateElement("Account");
			account.SetAttribute("ID", GetID());

			XmlElement firstName = xmlDoc.CreateElement("FirstName");
			firstName.InnerText = FirstName;
			XmlElement lastName = xmlDoc.CreateElement("LastName");
			lastName.InnerText = LastName;
			XmlElement email = xmlDoc.CreateElement("Email");
			email.InnerText = Email;
			XmlElement password = xmlDoc.CreateElement("Password");
			password.InnerText = CalculateMD5Hash(Password);

			account.AppendChild(firstName);
			account.AppendChild(lastName);
			account.AppendChild(email);
			account.AppendChild(password);

			return Convert.ToString(account.OuterXml);
		}

		public static string CalculateMD5Hash(string input)
		{

			// step 1, calculate MD5 hash from input

			MD5 md5 = System.Security.Cryptography.MD5.Create();

			byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

			byte[] hash = md5.ComputeHash(inputBytes);

			// step 2, convert byte array to hex string

			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < hash.Length; i++)
			{

				sb.Append(hash[i].ToString("X2"));

			}

			return sb.ToString();
		}
		public string GetAccountsCount()
		{
			XmlDocument doc = new XmlDocument();
			doc.Load("Users.xml");

			XmlElement root = doc.DocumentElement;
			XmlNodeList elemList = root.GetElementsByTagName("Account");

			return elemList.Count.ToString();
			//if (true)
			//{
			//	for (int i = 0; i < elemList.Count; i++)
			//	{
			//		return elemList.ToString();
			//	}
			//}
			//return "b";
		}

		string GetID()
		{
			string lastID = "0";
			XmlTextReader reader = new XmlTextReader("Users.xml");

			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element && reader.Name == "Account")
				{
					lastID = reader.GetAttribute("ID");
				}
			}

			reader.Close();

			RegistrID = lastID;

			return (Convert.ToInt32(lastID) + 1).ToString();
		}
	}
}
