using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Usando_Datatable
{
    public partial class Form1 : Form
    {
        DataTable dtb_Rotas;
        string[] last10 = new string[10];
        string[] last10Aux = new string[10];
        string[] rota1 = new string[15];
        string[] rota2 = new string[15];
        string[] ROTAS = new string[100];
        int cont = 9;
        int idx = 0;
        string[] select = new string[2];
        float[] tempoTotal = new float[2];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cboCampo.SelectedIndex = 1;
        }

        private void txtCriterio_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSelecionarRota.Enabled = true;
        }

        private void btnCriarDataTable_Click(object sender, EventArgs e)
        {
            DataTable tabela = CriarDataTable();
            dgvDados.DataSource = tabela;
            dgvDados.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDados.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDados.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDados.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDados.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDados.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDados.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDados.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDados.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDados.Columns[0].HeaderCell.Style.Font = new Font("Arial", 9F, FontStyle.Bold);

           if (dgvDados.Rows.Count > 0)
            {
                this.btnSelecionarRota.Enabled = false;
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.lblSelecao.Text = "_________";
            }
        }
        private DataTable CriarDataTable()
        {
            dtb_Rotas = new DataTable();

            dtb_Rotas.Columns.Add("POSIÇÃO",   typeof(string));
            dtb_Rotas.Columns.Add("Norte",     typeof(string));
            dtb_Rotas.Columns.Add("Norte(T)",  typeof(float));
            dtb_Rotas.Columns.Add("Sul",       typeof(string));
            dtb_Rotas.Columns.Add("Sul(T)",    typeof(float));
            dtb_Rotas.Columns.Add("Leste",     typeof(string));
            dtb_Rotas.Columns.Add("Leste(T)",  typeof(float));
            dtb_Rotas.Columns.Add("Oeste",     typeof(string));
            dtb_Rotas.Columns.Add("Oeste(T)",  typeof(float));

            GetAllProdutos();

            return dtb_Rotas;
        }

        //------------------------------------------ acessando a Web API ------------------------------------------
        private async void GetAllProdutos()
        {
            string URI = "https://mocki.io/v1/10404696-fd43-4481-a7ed-f9369073252f";
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //clienteUri = response.Headers.Location;
                        var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                        string position, nextPosition = "";

                        dynamic jsonObj = JsonConvert.DeserializeObject(ProdutoJsonString);

                        foreach (dynamic P1 in jsonObj)
                        {
                            position = $"{P1}".ToString();
                            position = position.Split(':')[0].Replace("\"", "");
                            position = position.Replace(" ", "");
                            position = position.Replace("\n", "");
                            position = position.Replace("\r", "");
                            position = position.Replace("\t", "");
                            position = position.Replace("{", "");

                            foreach (dynamic P2 in P1)
                            {
                                int i = 0;
                                string[] letter = {"X","X","X","X"}, time = { "0","0","0","0"};
                                foreach (dynamic P3 in P2)
                                {
                                    nextPosition = $"{P3}".ToString();
                                    letter[i] = nextPosition.Split(':')[0];
                                    letter[i] = letter[i].Replace("\"", "");
                                    time[i] = nextPosition.Split(':')[1];
                                    time[i] = time[i].Replace(" ", "");
                                    i++;
                                }
                                dtb_Rotas.Rows.Add(position, 
                                    letter[0], float.Parse(time[0].Replace(".", ",")), 
                                    letter[1], float.Parse(time[1].Replace(".", ",")), 
                                    letter[2], float.Parse(time[2].Replace(".", ",")), 
                                    letter[3], float.Parse(time[3].Replace(".", ",")));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o produto : " + response.StatusCode);
                    }
                }
            }
        }

        private void btnSelecionarRota_Click(object sender, EventArgs e)
        {
            searchRoute();

            list10();
        }

        private void list10()
        {
            string listSelect = "";

            if (tempoTotal[0] < tempoTotal[1])
            {
                listSelect = select[0] + " = " + tempoTotal[0];
                lblSelecao.Text = listSelect;
            }
            else
            {
                listSelect = select[1] + " = " + tempoTotal[1];
                lblSelecao.Text = listSelect;
            }

            if (cont >= 0)
            {
                last10.SetValue(listSelect, cont);
                cont -= 1;
            }
            else
            {
                last10Aux.SetValue(listSelect, 0);
                for (int i = 0; i <= 8; i++)
                {
                    last10Aux.SetValue(last10[i], (i + 1));
                }

                Array.Clear(last10, 0, 9);
                for (int i = 0; i <= 9; i++)
                {
                    last10.SetValue(last10Aux[i], i);
                }
                Array.Clear(last10Aux, 0, 9);
            }

            lbDados.Items.Clear();
            for (int i = 0; i <= 9; i++)
            {
                if (!string.IsNullOrEmpty(last10[i]))
                {
                    lbDados.Items.Add(last10[i]);
                }
            }
            Array.Clear(tempoTotal, 0, 1);
            Array.Clear(select, 0, 1);
        }

        private string searchRoute()
        {
            string partida = textBox1.Text;
            string objeto = textBox2.Text;
            string destino = textBox3.Text;

            Array.Clear(rota1, 0, 15);
            Array.Clear(rota2, 0, 15);
            tempoTotal[0] = 0; tempoTotal[1] = 0;
            select[0] = ""; select[1] = "";

            idx = 0;

            // 1° caminho possível
            idx = 0;
            getRoute1(partida, objeto);
            getRoute1(objeto, destino);

            // 2° caminho possível
            idx = 0;
            getRoute2(partida, objeto);
            getRoute2(objeto, destino);

            fasterRoute();

            return "";
        }

        private void fasterRoute()
        {
            string campo = "POSIÇÃO";
            string comando = "";

            ROTAS[11] = "A1"; ROTAS[21] = "B1"; ROTAS[31] = "C1"; ROTAS[41] = "D1";
            ROTAS[12] = "A2"; ROTAS[22] = "B2"; ROTAS[32] = "C2"; ROTAS[42] = "D2";
            ROTAS[13] = "A3"; ROTAS[23] = "B3"; ROTAS[33] = "C3"; ROTAS[43] = "D3";
            ROTAS[14] = "A4"; ROTAS[24] = "B4"; ROTAS[34] = "C4"; ROTAS[44] = "D4";
            ROTAS[15] = "A5"; ROTAS[25] = "B5"; ROTAS[35] = "C5"; ROTAS[45] = "D5";
            ROTAS[16] = "A6"; ROTAS[26] = "B6"; ROTAS[36] = "C6"; ROTAS[46] = "D6";
            ROTAS[17] = "A7"; ROTAS[27] = "B7"; ROTAS[37] = "C7"; ROTAS[47] = "D7";
            ROTAS[18] = "A8"; ROTAS[28] = "B8"; ROTAS[38] = "C8"; ROTAS[48] = "D8";

            ROTAS[51] = "E1"; ROTAS[61] = "F1"; ROTAS[71] = "G1"; ROTAS[81] = "H1";
            ROTAS[52] = "E2"; ROTAS[62] = "F2"; ROTAS[72] = "G2"; ROTAS[82] = "H2";
            ROTAS[53] = "E3"; ROTAS[63] = "F3"; ROTAS[73] = "G3"; ROTAS[83] = "H3";
            ROTAS[54] = "E4"; ROTAS[64] = "F4"; ROTAS[74] = "G4"; ROTAS[84] = "H4";
            ROTAS[55] = "E5"; ROTAS[65] = "F5"; ROTAS[75] = "G5"; ROTAS[85] = "H5";
            ROTAS[56] = "E6"; ROTAS[66] = "F6"; ROTAS[76] = "G6"; ROTAS[86] = "H6";
            ROTAS[57] = "E7"; ROTAS[67] = "F7"; ROTAS[77] = "G7"; ROTAS[87] = "H7";
            ROTAS[58] = "E8"; ROTAS[68] = "F8"; ROTAS[78] = "G8"; ROTAS[88] = "H8";

            select[0] = ROTAS[int.Parse(rota1[0])];
            for (int i = 0; i < 14; i++)
            {
                string dir = "";
                if (rota1[i + 1] != null)
                {
                    comando = campo + "=" + "'" + ROTAS[int.Parse(rota1[i])] + "'";
                    DataRow[] dtPosition = dtb_Rotas.Select(comando);
                    foreach (DataRow dr in dtPosition)
                    {
                        int j = 0;
                        do
                        {
                            dir = dr[j].ToString();
                            if (ROTAS[int.Parse(rota1[i + 1])] == dir)
                            {
                                select[0] = select[0] + " > " + dir;
                                tempoTotal[0] += float.Parse(dr[j + 1].ToString());
                                j = 0;
                            }
                            else
                            {
                                j++;
                            }
                        }
                        while (j > 0);
                    }
                }
            }

            select[1] = ROTAS[int.Parse(rota2[0])];
            for (int i =0; i < 14; i++)
            {
                string dir = "";
                if (rota2[i + 1] != null)
                {
                    comando = campo + "=" + "'" + ROTAS[int.Parse(rota2[i])] + "'";
                    DataRow[] dtPosition = dtb_Rotas.Select(comando);
                    foreach (DataRow dr in dtPosition)
                    {
                        int j = 0;
                        do
                        {
                            dir = dr[j].ToString();
                            if (ROTAS[int.Parse(rota2[i + 1])] == dir)
                            {
                                select[1] = select[1] + " > " + dir;
                                tempoTotal[1] += float.Parse(dr[j + 1].ToString());
                                j = 0;
                            }
                            else
                            {
                                j++;
                            }
                        }
                        while (j > 0);
                    }
                }
            }
        }

        private void getRoute1(string ini, string fim)
        {
            int pontoCol1 = 0, pontoCol2 = 0, pontoRow1 = 0, pontoRow2 = 0, firstPonto = 0, lastPonto = 0;

            pontoCol1 = int.Parse(getCollum(ini.Substring(0, 1), 1));
            pontoCol2 = int.Parse(getCollum(fim.Substring(0, 1), 1));

            pontoRow1 = int.Parse(ini.Substring(1, 1));
            pontoRow2 = int.Parse(fim.Substring(1, 1));

            firstPonto = int.Parse(getCollum(ini.Substring(0, 1), 1) + ini.Substring(1, 1));
            lastPonto = int.Parse(getCollum(fim.Substring(0, 1), 1) + fim.Substring(1, 1));

            int P1 = firstPonto;
            int P2 = int.Parse(pontoCol2.ToString() + pontoRow1.ToString());

            if (pontoCol1 < pontoCol2)
            {
                for (int i = P1; i <= P2; i += 10) //primeiro pedaço do caminho
                {
                    if (idx > 0)
                    {
                        if (rota1[idx - 1] != i.ToString())
                        {
                            rota1[idx] = i.ToString();
                            idx++;
                        }
                    }
                    else
                    {
                        rota1[idx] = i.ToString();
                        idx++;
                    }
                }
            }
            else if (pontoCol1 > pontoCol2) //primeiro pedaço do caminho
            {
                for (int i = P1; i >= P2; i -= 10)
                {
                    if (idx > 0)
                    {
                        if (rota1[idx - 1] != i.ToString())
                        {
                            rota1[idx] = i.ToString();
                            idx++;
                        }
                    }
                    else
                    {
                        rota1[idx] = i.ToString();
                        idx++;
                    }
                }
            }

            if (lastPonto < P2) //segundo pedaço do caminho
            {
                for (int i = P2; i >= lastPonto; i--)
                {
                    if (idx > 0)
                    {
                        if (rota1[idx - 1] != i.ToString())
                        {
                            rota1[idx] = i.ToString();
                            idx++;
                        }
                    }
                    else
                    {
                        rota1[idx] = i.ToString();
                        idx++;
                    }
                }
            }
            else if (lastPonto > P2)
            {
                for (int i = P2; i <= lastPonto; i++)
                {
                    if (idx > 0)
                    {
                        if (rota1[idx - 1] != i.ToString())
                        {
                            rota1[idx] = i.ToString();
                            idx++;
                        }
                    }
                    else
                    {
                        rota1[idx] = i.ToString();
                        idx++;
                    }
                }
            }
        }

        private void getRoute2(string ini, string fim)
        {
            int pontoCol1 = 0, pontoRow1 = 0, pontoRow2 = 0, firstPonto = 0, lastPonto = 0;

            pontoCol1 = int.Parse(getCollum(ini.Substring(0, 1), 1));
            //pontoCol2 = int.Parse(getCollum(fim.Substring(0, 1), 1));

            pontoRow1 = int.Parse(ini.Substring(1, 1));
            pontoRow2 = int.Parse(fim.Substring(1, 1));

            firstPonto = int.Parse(getCollum(ini.Substring(0, 1), 1) + ini.Substring(1, 1));
            lastPonto = int.Parse(getCollum(fim.Substring(0, 1), 1) + fim.Substring(1, 1));

            int P1 = firstPonto;
            int P2 = int.Parse(pontoCol1.ToString() + pontoRow2.ToString());

            if (P1 < P2) //primeiro pedaço do caminho
            {
                for (int i = (P1); i <= P2; i++)
                {
                    if (idx > 0)
                    {
                        if (rota2[idx - 1] != i.ToString())
                        {
                            rota2[idx] = i.ToString();
                            idx++;
                        }
                    }
                    else
                    {
                        rota2[idx] = i.ToString();
                        idx++;
                    }
                }
            }
            else if (P1 > P2)
            {
                for (int i = (P1); i >= P2; i--)
                {
                    if (idx > 0)
                    {
                        if (rota2[idx - 1] != i.ToString())
                        {
                            rota2[idx] = i.ToString();
                            idx++;
                        }
                    }
                    else
                    {
                        rota2[idx] = i.ToString();
                        idx++;
                    }
                }
            }

            if (lastPonto < P2) //segundo pedaço do caminho
            {
                for (int i = P2; i >= lastPonto; i -= 10)
                {
                    if (idx > 0)
                    {
                        if (rota2[idx - 1] != i.ToString())
                        {
                            rota2[idx] = i.ToString();
                            idx++;
                        }
                    }
                    else
                    {
                        rota2[idx] = i.ToString();
                        idx++;
                    }
                }
            }
            else if (lastPonto > P2)
            {
                for (int i = P2; i <= lastPonto; i += 10)
                {
                    if (idx > 0)
                    {
                        if (rota2[idx - 1] != i.ToString())
                        {
                            rota2[idx] = i.ToString();
                            idx++;
                        }
                    }
                    else
                    {
                        rota2[idx] = i.ToString();
                        idx++;
                    }
                }
            }
        }

        private string getCollum(string posicao, int flg)
        {
            string col = "";

            if (flg == 1)
            {
                posicao = posicao.Substring(0, 1);

                switch (posicao)
                {
                    case "A":
                        col = "1";
                        break;
                    case "B":
                        col = "2";
                        break;
                    case "C":
                        col = "3";
                        break;
                    case "D":
                        col = "4";
                        break;
                    case "E":
                        col = "5";
                        break;
                    case "F":
                        col = "6";
                        break;
                    case "G":
                        col = "7";
                        break;
                    case "H":
                        col = "8";
                        break;
                }
            }
            else if (flg == 2)
            {
                col = "";
            }
            return col;
        }

        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            string posicao = dgvDados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (Regex.IsMatch(posicao, "^[A-H]+[1-8]$"))
            {
                if (string.IsNullOrEmpty(this.textBox1.Text))
                {
                    this.textBox1.Text = posicao;
                }
                else if (string.IsNullOrEmpty(this.textBox2.Text))
                {
                    this.textBox2.Text = posicao;
                }
                else if (string.IsNullOrEmpty(this.textBox3.Text))
                {
                    this.textBox3.Text = posicao;

                    if(!string.IsNullOrEmpty(posicao))
                        this.btnSelecionarRota.Enabled = true;
                }
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.btnSelecionarRota.Enabled = false;
            this.lblSelecao.Text = "_________";
        }
    }
}