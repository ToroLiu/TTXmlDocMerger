### Goal
In order to merge C# Xml documents to be one. 

### Usage

    string xml1 = ... // The 1st xml doc path.
    string xml2 = ... // The 2nd xml doc path.

    // Merge xml1 and xml2.
    XmlDocMerger helper = new XmlDocMerger(xml1);
    helper.AddDoc(xml2);

    // Get the merged result.
    string resultXmlPath = helper.GetTempfilePath();