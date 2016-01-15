Module Module1

    Sub Main()
      With My.Computer.FileSystem.SpecialDirectories
         Dim Datos =
          {{"AllUsersApplicationData", .AllUsersApplicationData},
           {"CurrentUserApplicationData", .CurrentUserApplicationData},
           {"Desktop", .Desktop}, {"MyDocuments", .MyDocuments},
           {"MyMusic", .MyMusic}, {"MyPictures", .MyPictures},
           {"Programs", .Programs}, {"Temp", .Temp}}

         For Indice = 0 To Datos.GetUpperBound(0)
            Console.WriteLine(Datos(Indice, 0) & ": " & Datos(Indice, 1))
         Next
      End With

    End Sub

End Module
