using System;
namespace MultivaluedDictionary
{
	public interface IMultiValueDictionary
	{
		public string Add(string key, string value);
		public string Remove(string key, string value);
		public string Remove(string key);
		public bool KeyExists(string key);
		public bool MemberExists(string key, string value);
		public string Keys();
		public string Members(string key);
		public string PrintAllItems();
		public string AllMembers();
		public void Clear();
		public int Count();
	}
}

