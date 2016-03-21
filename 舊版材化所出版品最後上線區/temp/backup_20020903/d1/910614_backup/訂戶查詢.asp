<SCRIPT LANGUAGE=jscript RUNAT=Server>
var vType = Request.Form("type");
var vKeyword = Request.Form("keyword");

var xmlDoc = Server.CreateObject("MSXML2.DOMDocument.3.0");
xmlDoc.async = false;
xmlDoc.setProperty("SelectionLanguage", "XPath");
xmlDoc.load(Server.MapPath("­q¤á¸ê®Æ.xml"));
xmlDoc.save(Response);
var xmlDoc = null;
</script>
