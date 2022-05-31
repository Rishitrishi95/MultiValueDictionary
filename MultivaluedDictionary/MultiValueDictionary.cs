using System;
using System.Text;

namespace MultivaluedDictionary
{
    public class MultiValueDictionary : IMultiValueDictionary
    {
        private Dictionary<string, List<string>> multiValueDictionaryObject;

        /*Constructor to initialize dictionary object*/
        public MultiValueDictionary()
        {
            multiValueDictionaryObject = new Dictionary<string, List<string>>();
        }


        /*Method to add key value pair and doesn't allow duplicate values for same key*/
        public string Add(string key, string value)
        {
            if(multiValueDictionaryObject.ContainsKey(key))
            {

                if (multiValueDictionaryObject[key].Contains(value))
                {
                    return $"Error, Member {value} already exists in Key {key}";
                }
                else
                {
                    multiValueDictionaryObject[key].Add(value);

                    return $"Successfully added {value} to {key}";
                }
            }
            else
            {
                multiValueDictionaryObject.Add(key,new List<string>() { value });

                return $"Successfully added {value} to {key}";
            }
        }

        /*Remove key value pair if exists, also removes key if the value list is empty*/
        public string Remove(string key, string value)
        {
            if(multiValueDictionaryObject.ContainsKey(key))
            {
                if(multiValueDictionaryObject[key].Remove(value))
                {
                    if (multiValueDictionaryObject[key].Count==0)
                    {
                        multiValueDictionaryObject.Remove(key);
                    }
                    return $"Successfully removed Member - {value} from Key - {key}";
                }
                else
                {
                    return $"Member - {value} doesn't exist, Removal unsuccessfull";
                }
            }
            else
            {
               return $"Key - {key} doesn't exist, Removal unsuccessfull";
            }
        }

        /*Removes key from dictionary*/
        public string Remove(string key)
        {
            if(multiValueDictionaryObject.Remove(key))
            {
                return $"Successfully removed Key - {key}";
            }
            else
            {
                return $"Key {key} doesn't exist, Removal unsuccessfull";
            }
        }

        /*checks if key exists*/
        public bool KeyExists(string key)
        {
            if (multiValueDictionaryObject.ContainsKey(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /*checks if key value pair exists*/
        public bool MemberExists(string key, string value)
        {
            if (multiValueDictionaryObject.ContainsKey(key) && multiValueDictionaryObject[key].Contains(value))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /*Prints all the keys in dictionary, with first in order*/
        public string Keys()
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            if (multiValueDictionaryObject.Count > 0)
            {
                foreach (string key in multiValueDictionaryObject.Keys)
                {
                    sb.AppendLine($"{++counter}) {key}");
                }
                return sb.ToString();
            }
            else
            {
                return ") Empty Set";
            }
        }

        /*Prints all the members of given key*/
        public string Members(string key)
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            if (KeyExists(key))
            {
                foreach (string value in multiValueDictionaryObject[key])
                {
                    sb.AppendLine($"{++counter}) {value}");
                }
                return sb.ToString();
            }
            else
            {
                return $"Key {key} doesn't exist";
            }

        }


        /*Prints all the key, value pairs in dictionary*/
        public string PrintAllItems()
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            if (multiValueDictionaryObject.Count > 0)
            {
                foreach (string key in multiValueDictionaryObject.Keys)
                {
                    foreach (string value in multiValueDictionaryObject[key])
                    {
                        sb.AppendLine($"{++counter}) {key}: {value}");
                    }
                }
                return sb.ToString();
            }
            else
            {
                return "No key value pair exists in dictionary";
            }
        }


        /*Prints all the members in the dictionary*/
        public string AllMembers()
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            if (multiValueDictionaryObject.Count > 0)
            {
                foreach (string key in multiValueDictionaryObject.Keys)
                {
                    foreach (string value in multiValueDictionaryObject[key])
                    {
                        sb.AppendLine($"{++counter}) {value}");
                    }
                }
                return sb.ToString();
            }
            else
            {
                return "No member exists";
            }
        }

        /*Removes all keys and values from dictionary*/
        public void Clear()
        {
            multiValueDictionaryObject.Clear();
        }

        public int Count()
        {
            return multiValueDictionaryObject.Count();
        }
    }
}

