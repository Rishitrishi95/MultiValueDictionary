using MultivaluedDictionary;
namespace DictionaryUnitTest;

public class Tests
{
    public MultiValueDictionary multiValueDict;

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
        Assert.That(response,Is.EqualTo($"Successfully added {value} to {key}\n"));
    }
    [Test]
    public void TestAdd2()
    {
        multiValueDict.Add("foo", "bar");

        string key = "foo";
        string value = "baz";
        var response = multiValueDict.Add(key,value);
        Assert.That(response, Is.EqualTo($"Successfully added {value} to {key}\n"));
    }
    [Test]
    public void TestAddFail()
    {
        string key = "foo";
        string value = "bar";
        multiValueDict.Add("foo", "bar");
        var response = multiValueDict.Add("foo", "bar");
        Assert.That(response, Is.EqualTo($"Error, Member {value} already exists in Key {key}\n"));
    }

    [Test]
    public void TestRemove()
    {
        string key = "foo";
        string value = "bar";
        multiValueDict.Add("foo", "bar");
        var response = multiValueDict.Remove("foo", "bar");
        Assert.That(response, Is.EqualTo($"Successfully removed Member - {value} from Key - {key}\n"));
    }

    [Test]
    public void TestRemoveFailBecauseOfMemberDoesntExists()
    {
        string value = "baz";
        multiValueDict.Add("foo", "bar");
        var response = multiValueDict.Remove("foo", "baz");
        Assert.That(response, Is.EqualTo($"Member - {value} doesn't exist, Removal unsuccessfull\n"));
    }

    public void TestRemoveFailBecauseOfKeyDoesntExists()
    {
        string key = "zoo";
        multiValueDict.Add("foo", "bar");
        var response = multiValueDict.Remove("zoo", "baz");
        Assert.That(response, Is.EqualTo($"Key - {key} doesn't exist, Removal unsuccessfull\n"));
    }

    [Test]
    public void TestRemoveAll()
    {
        multiValueDict.Add("foo", "bar");
        multiValueDict.Add("foo", "baz");
        multiValueDict.Add("foo", "zam");
        if(multiValueDict.Count()==3)
        {
            multiValueDict.Remove("foo");
            var response = multiValueDict.KeyExists("foo");
            Assert.That(response, Is.EqualTo(false));
        }
    }

    [Test]
    public void TestRemoveAllFail()
    {
        string key = "zoo";
        multiValueDict.Add("foo", "bar");
        var response = multiValueDict.Remove("zoo");
        Assert.That(response, Is.EqualTo($"Key {key} doesn't exist, Removal unsuccessfull\n"));
    }

    //[Test]
    //public void TestMemberExists()
    //{
    //    string key = "foo";
    //    string value = "bar";
    //    multiValueDict.Add("foo", "bar");
    //    var response = multiValueDict.Add("foo", "bar");
    //    Assert.That($"Error, Member {value} already exists in Key {key}", Is.EqualTo(response));
    //}

    //[Test]
    //public void TestMemberDoesnNotExists()
    //{
    //    string key = "foo";
    //    string value = "bar";
    //    multiValueDict.Add("foo", "bar");
    //    var response = multiValueDict.Add("foo", "bar");
    //    Assert.That($"Error, Member {value} already exists in Key {key}", Is.EqualTo(response));
    //}

    //[Test]
    //public void TestKeyExists()
    //{
    //    string key = "foo";
    //    string value = "bar";
    //    multiValueDict.Add("foo", "bar");
    //    var response = multiValueDict.Add("foo", "bar");
    //    Assert.That($"Error, Member {value} already exists in Key {key}", Is.EqualTo(response));
    //}

    //[Test]
    //public void TestKeyDoesnNotExists()
    //{
    //    string key = "foo";
    //    string value = "bar";
    //    multiValueDict.Add("foo", "bar");
    //    var response = multiValueDict.Add("foo", "bar");
    //    Assert.That($"Error, Member {value} already exists in Key {key}", Is.EqualTo(response));
    //}



    [Test]
    public void TestKeys()
    {
        multiValueDict.Add("foo", "bar");
        multiValueDict.Add("baz", "bang");
        var response = multiValueDict.Keys();
        Assert.That(response, Is.EqualTo($"1) foo\n2) baz\n"));
    }


    [Test]
    public void TestClear()
    {
        multiValueDict.Add("foo", "bar");
        multiValueDict.Add("baz", "bang");
        if(multiValueDict.Count()==2)
        {
            multiValueDict.Clear();
            var response = multiValueDict.Count();
            Assert.That(response,Is.EqualTo(0));
        }
    }


}
