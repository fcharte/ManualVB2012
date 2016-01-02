Imports System.Xml.Linq

Module Module1

   Sub Main()
      ' Asignación de un literal XML a una variable
      Dim Lista =
         <?xml version="1.0" encoding="UTF-8"?>
         <opml version="1.1">
            <head>
               <title>
                  <![CDATA[Lista OPML de feeds]]>
               </title>
            </head>
            <body>
               <outline text="TechCrunch" title="TechCrunch"
                  xmlUrl="http://feeds.feedburner.com/Techcrunch"
                  htmlUrl="http://www.techcrunch.com" type="rss">
               </outline>
               <outline text="Slashdot" title="Slashdot"
                  xmlUrl="http://rss.slashdot.org/Slashdot/slashdot"
                  htmlUrl="http://slashdot.org/" type="rss">
               </outline>
               <outline text="Engadget" title="Engadget"
                  xmlUrl="http://www.engadget.com/rss.xml"
                  htmlUrl="http://www.engadget.com">
               </outline>
            </body>
         </opml>

      ' Consulta para recuperar información del documento XML
      Dim Entradas =
        From E In Lista.Descendants("outline") Where
          E.Attributes("title").Count() <> 0
        Select New With {.Titulo = E.Attribute("title").Value, _
                         .Direccion = E.Attribute("xmlUrl").Value}

      ' Se recorre el resultado y muestran las entradas
      For Each Entrada In Entradas
         Console.WriteLine(Entrada.Titulo & " --> " & Entrada.Direccion)
      Next
      Dim ctx As System.Data.Linq.DataContext
   End Sub

End Module
