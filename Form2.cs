using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace Painel_Anjo_Stroe
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Mem Memory = new Mem();

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                Sta1.Text = "Abra o Seu Emulador";
            }
            else
            {
                Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
                Memory.OpenProcess(proc);
                Sta1.Text = "Ativando Bala No Globo";

                var result = await Memory.AoBScan("00 00 00 00 00 00 A5 43 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF", true, true);
                if (result.Any())
                {
                    foreach (var CurrentAddress in result)
                    {
                        Int64 Enderecoleitura = CurrentAddress + 0x2c;
                        Int64 EndercoEscrita = CurrentAddress + 0x28;

                        var Read = Memory.ReadMemory<int>(Enderecoleitura.ToString("X"));
                        Memory.WriteMemory(EndercoEscrita.ToString("X"), "int", Read.ToString());

                        Sta1.Text = "Bala No Globo Ativado✅";
                    }

                }
                else
                {
                    Sta1.Text = "Falha ao Ativar";
                }
            }
        }
    }
}
