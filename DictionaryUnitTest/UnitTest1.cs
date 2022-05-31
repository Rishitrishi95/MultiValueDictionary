using MultivaluedDictionary;
namespace DictionaryUnitTest;

public class Tests
{
    private MultiValueDictionary multiValueDict;

    [SetUp]
    public void Setup()
    {
        multiValueDict = new MultiValueDictionary();
    }

    [Test]
    public void TestAdd()
    {
        string key = "foo";
        string value = "bar";
        var response=multiValueDict.Add("foo", "bar");
        Assert.That($"Successfully added {value} to {key}",Is.EqualTo(response));
    }
    [Test]
    public void TestAdd2()
    {
        string key = "foo";
        string value = "baz";
        var response = multiValueDict.Add(key,value);
        Assert.That($"Successfully added {value} to {key}", Is.EqualTo(response));
    }
    [Test]
    public void TestAddFail()
    {
        string key = "foo";
        string value = "bar";
        multiValueDict.Add("foo", "bar");
        var response = multiValueDict.Add("foo", "bar");
        Assert.That($"Error, Member {value} already exists in Key {key}", Is.EqualTo(response));
    }


    [Test]
    public void TestKeys()
    {
        multiValueDict.Add("foo", "bar");
        multiValueDict.Add("baz", "bang");
        var response = multiValueDict.Keys();
        Assert.That($"1) foo \n 2) baz", Is.EqualTo(response));
    }

}
