using ImGuiNET;
using OpenPuppet.SDK;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace OpenPuppet.Core.Dialogs
{
    public class ErrorDialog : IUIDialog
    {
        public string Title { get; set; } = "Error";
        public ImGuiWindowFlags? Flags { get; set; } = null;
        public Vector2? Size { get; set; } = null;

        private bool error = false;

        private Exception? ex;
        private string? msg;

        public void OnLoad()
        {

        }

        public void OnPreRender()
        {
            
        }

        public void OnRender()
        {
            if(ex == null && msg == null)
            {
                ImGui.Text("One sec...");
                return;
            }

            if (error) ImGui.TextColored(new(255, 0, 0, 255), "Error");
            else ImGui.TextColored(new(128, 128, 0, 255), "Warning");

            ImGui.Text(ex?.ToString() ?? msg ?? "");
        }

        public void OnClose()
        {
            
        }

        public void RelayError(Exception ex)
        {
            this.ex = ex;
            error = true;
        }

        public void RelayError(string err)
        {
            msg = err;
            error = true;
        }

        public void RelayWarning(string warning)
        {
            msg = warning;
        }
    }
}
