## .Net Client for Ploteus Turkey Integration Pool

##$ Example usage for uploading qualifications:

```csharp
string qualificationsXml = ".....";
var client = new PloteusWebClient("CHANGE_WITH_YOUR_USERNAME", "CHANGE_WITH_YOUR_PASSWORD");
var response = client.uploadQualificationsXml(qualificationsXml);
```
