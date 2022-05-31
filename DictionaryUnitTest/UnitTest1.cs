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

    [Test]
    public void TestMemberExists()
    {
        multiValueDict.Add("foo", "bar");
        var response = multiValueDict.MemberExists("foo", "BAR");
        Assert.That(response, Is.EqualTo(true));
        response = multiValueDict.MemberExists("foo", "bar");
        Assert.That(response, Is.EqualTo(true));
        response = multiValueDict.MemberExists("foo", "baz");
        Assert.That(response, Is.EqualTo(false));

        response = multiValueDict.MemberExists("zoo", "bar");
        Assert.That(response, Is.EqualTo(false));
    }

    [Test]
    public void TestKeyExists()
    {
        multiValueDict.Add("foo", "bar");
        var response = multiValueDict.KeyExists("foo");
        Assert.That(response, Is.EqualTo(true));
        response = multiValueDict.KeyExists("FOO");
        Assert.That(response, Is.EqualTo(true));
        response = multiValueDict.KeyExists("zoo");
        Assert.That(response, Is.EqualTo(false));
    }


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

    [Test]
    public void TestMembers()
    {
        multiValueDict.Add("foo", "bar");
        multiValueDict.Add("foo", "bang");
        var response = multiValueDict.Members("foo");
        Assert.That(response, Is.EqualTo($"1) bar\n2) bang\n"));
    }

    [Test]
    public void TestAllMembers()
    {
        multiValueDict.Add("foo", "bar");
        multiValueDict.Add("foo", "bang");
        multiValueDict.Add("bar", "zoo");
        multiValueDict.Add("bar", "soda");
        var response = multiValueDict.AllMembers();
        Assert.That(response, Is.EqualTo($"1) bar\n2) bang\n3) zoo\n4) soda\n"));
    }

    [Test]
    public void TestList()
    {
        multiValueDict.Add("foo", "bar");
        multiValueDict.Add("foo", "bang");
        multiValueDict.Add("bar", "zoo");
        multiValueDict.Add("bar", "soda");
        var response = multiValueDict.PrintAllItems();
        Assert.That(response, Is.EqualTo($"1) foo: bar\n2) foo: bang\n3) bar: zoo\n4) bar: soda\n"));
    }



}
