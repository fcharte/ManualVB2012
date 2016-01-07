Public Class Form1

   Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
      With My.Computer.Keyboard
         cbAlt.Checked = .AltKeyDown
         cbControl.Checked = .CtrlKeyDown
         cbMayus.Checked = .ShiftKeyDown
         cbCaps.Checked = .CapsLock
         cbNum.Checked = .NumLock
         cbScroll.Checked = .ScrollLock
      End With
   End Sub
End Class
