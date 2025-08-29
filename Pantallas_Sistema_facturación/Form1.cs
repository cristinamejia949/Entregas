// Archivo único: PantallasSistemaFacturacion.cs
// Proyecto: Pantallas_Sistema_facturacion
// Instrucciones: Cree un proyecto de tipo "Windows Forms App (.NET Framework)" o ".NET 6/7 Windows Forms" y reemplace Program.cs por este archivo
// (o copie las clases dentro del proyecto). Este archivo contiene todas las formas (sin diseñador) y lógica básica en memoria.


using Pantallas_Sistema_facturacion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace Pantallas_Sistema_facturacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // Iniciar con el formulario de login
            using (var login = new LoginForm())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm(login.LoggedUserName));
                }
            }
        }
    }


    // ------------------------- MODELOS ---------------------------------
    public class Client
    {
        private Label lblTitle;


        public string LoggedUserName { get; private set; }


        public LoginForm()
        {
            InitializeComponents();
        }


        private void InitializeComponents()
        {
            Text = "Ingresar - Sistema de Facturación";
            Size = new Size(420, 300);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;


            BackColor = Color.FromArgb(30, 30, 36);


            lblTitle = new Label
            {
                Text = "Bienvenido - Iniciar sesión",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };


            var panel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };


            var lblUser = new Label { Text = "Usuario", ForeColor = Color.White, AutoSize = false, Height = 18 };
            txtUsername = new TextBox { PlaceholderText = "usuario", Height = 28 };
            var lblPass = new Label { Text = "Contraseña", ForeColor = Color.White, AutoSize = false, Height = 18 };
            txtPassword = new TextBox { UseSystemPasswordChar = true, PlaceholderText = "contraseña", Height = 28 };


            btnLogin = new Button { Text = "Entrar", Height = 36, Dock = DockStyle.Bottom, FlatStyle = FlatStyle.Flat };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += BtnLogin_Click;


            btnExit = new Button { Text = "Salir", Height = 36, Dock = DockStyle.Bottom, FlatStyle = FlatStyle.Flat };
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };


            // Controls layout
            var layout = new TableLayoutPanel { Dock = DockStyle.Top, Height = 140, RowCount = 4, ColumnCount = 1 };
            layout.RowStyles.Clear();
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));


            layout.Controls.Add(lblUser, 0, 0);
            layout.Controls.Add(txtUsername, 0, 1);
            layout.Controls.Add(lblPass, 0, 2);
            layout.Controls.Add(txtPassword, 0, 3);


            panel.Controls.Add(layout);
            panel.Controls.Add(btnExit);
            panel.Controls.Add(btnLogin);


            Controls.Add(panel);
            Controls.Add(lblTitle);


            AcceptButton = btnLogin;
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Validación simple: usuario: admin, pass: admin
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingrese usuario y contraseña.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // En una app real aquí iría la validación contra una base de datos o servicio
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                LoggedUserName = "admin";
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña inválidos. Pruebe admin/admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


    // ------------------------- MAIN FORM --------------------------------
    public class MainForm : Form
    {
{
currentUser = username;
SeedSampleData();
        InitializeComponents();
    }


    private void SeedSampleData()
    {
        // Datos de ejemplo para mostrar en la lista de clientes
        Clients.Add(new Client { Id = nextClientId++, FirstName = "Carlos", LastName = "Pérez", Email = "carlos@example.com", Phone = "12345678" });
        Clients.Add(new Client { Id = nextClientId++, FirstName = "María", LastName = "Gómez", Email = "maria@example.com", Phone = "87654321" });
    }


    private void InitializeComponents()
    {
        Text = "Pantallas - Sistema de Facturación";
        IsMdiContainer = true;
        WindowState = FormWindowState.Maximized;
        BackColor = Color.White;


        mainMenu = new MenuStrip { Dock = DockStyle.Top, RenderMode = ToolStripRenderMode.Professional, BackColor = Color.FromArgb(45, 45, 48), ForeColor = Color.White };


        // Menú Tablas
        var menuTablas = new ToolStripMenuItem("Tablas");
        var itemClientes = new ToolStripMenuItem("Formulario Clientes");
        itemClientes.Click += (_, __) => OpenClientList();
        var itemProductos = new ToolStripMenuItem("Formulario Productos");
        itemProductos.Click += (_, __) => OpenPlaceholderForm("Productos");
        var itemCategorias = new ToolStripMenuItem("Formulario Categorías");
        itemCategorias.Click += (_, __) => OpenPlaceholderForm("Categorías");
        menuTablas.DropDownItems.AddRange(new ToolStripItem[] { itemClientes, itemProductos, itemCategorias });


        // Menú Facturación
        var menuFacturacion = new ToolStripMenuItem("Facturación");
        var itemFacturas = new ToolStripMenuItem("Formulario Facturas");
        itemFacturas.Click += (_, __) => OpenPlaceholderForm("Facturas");
        var itemInformes = new ToolStripMenuItem("Formulario Informes");
        itemInformes.Click += (_, __) => OpenPlaceholderForm("Informes");
        menuFacturacion.DropDownItems.AddRange(new ToolStripItem[] { itemFacturas, itemInformes });


        // Menú Seguridad
        var menuSeguridad = new ToolStripMenuItem("Seguridad");
        var itemEmpleados = new ToolStripMenuItem("Formulario Empleados");
        itemEmpleados.Click += (_, __) => OpenPlaceholderForm("Empleados");
        var itemRoles = new ToolStripMenuItem("Formulario Roles");
        itemRoles.Click += (_, __) => OpenPlaceholderForm("Roles");
        var itemSeg = new ToolStripMenuItem("Formulario Seguridad");
        itemSeg.Click += (_, __) => OpenPlaceholderForm("Seguridad");
        menuSeguridad.DropDownItems.AddRange(new ToolStripItem[] { itemEmpleados, itemRoles, itemSeg });


        // Menú Ayuda
        var menuAyuda = new ToolStripMenuItem("Ayuda");
        var itemHelp = new ToolStripMenuItem("Formulario Ayuda");
        itemHelp.Click += (_, __) => OpenPlaceholderForm("Ayuda");
        var itemAbout = new ToolStripMenuItem("Acerca de");
        itemAbout.Click += (_, __) => OpenAbout();
        menuAyuda.DropDownItems.AddRange(new ToolStripItem[] { itemHelp, itemAbout });


        mainMenu.Items.AddRange(new ToolStripItem[] { menuTablas, menuFacturacion, menuSeguridad, menuAyuda });


        Controls.Add(mainMenu);


        // Status bar
        statusStrip = new StatusStrip();
        statusUser = new ToolStripStatusLabel($"Usuario: {currentUser}");
        statusStrip.Items.Add(statusUser);
        Controls.Add(statusStrip);
    }


    private void OpenClientList()
    {
        var frm = new ClientListForm(this) { MdiParent = this };
        frm.Show();
    }


    private void OpenPlaceholderForm(string title)
    {
        var frm = new PlaceholderForm(title) { MdiParent = this };
        frm.Show();
    }


    private void OpenAbout()
    {
        var frm = new AboutForm { MdiParent = this };
        frm.Show();
    }


    // Métodos para administración de clientes (usados por formularios hijos)
    public List<Client> GetAllClients() => Clients.ToList();
    public Client GetClientById(int id) => Clients.FirstOrDefault(c => c.Id == id);
    public Client AddClient(Client client)
    {
        client.Id = nextClientId++;
        Clients.Add(client);
        return client;
    }
    public bool UpdateClient(Client updated)
    {
        var existing = GetClientById(updated.Id);
        if (existing == null) return false;
        existing.FirstName = updated.FirstName;
        existing.LastName = updated.LastName;
        existing.Email = updated.Email;
        existing.Phone = updated.Phone;
        return true;
    }
    public bool DeleteClient(int id)
    {
        var c = GetClientById(id);
        if (c == null) return false;
        Clients.Remove(c);
        return true;
    }
}


// ------------------------- CLIENT LIST FORM (Listar y Actualizar) ---------------
panelButtons.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete });


Controls.Add(dgvClients);
Controls.Add(panelButtons);
}


private void LoadClientsToGrid()
{
    var list = _main.GetAllClients();
    dgvClients.DataSource = null;
    dgvClients.DataSource = list;
}


private Client GetSelectedClient()
{
    if (dgvClients.SelectedRows.Count == 0) return null;
    return dgvClients.SelectedRows[0].DataBoundItem as Client;
}


private void BtnAdd_Click(object sender, EventArgs e)
{
    var frm = new ClientEditForm(_main) { IsNew = true };
    if (frm.ShowDialog() == DialogResult.OK)
    {
        LoadClientsToGrid();
    }
}


private void BtnEdit_Click(object sender, EventArgs e)
{
    var sel = GetSelectedClient();
    if (sel == null) { MessageBox.Show("Seleccione un cliente para editar."); return; }
    var frm = new ClientEditForm(_main) { IsNew = false, EditingClient = sel };
    if (frm.ShowDialog() == DialogResult.OK)
    {
        LoadClientsToGrid();
    }
}


private void BtnDelete_Click(object sender, EventArgs e)
{
    var sel = GetSelectedClient();
    if (sel == null) { MessageBox.Show("Seleccione un cliente para eliminar."); return; }
    if (MessageBox.Show($"¿Eliminar cliente {sel.FirstName} {sel.LastName}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
    {
        _main.DeleteClient(sel.Id);
        LoadClientsToGrid();
    }
}
}


// ------------------------- CLIENT EDIT FORM -------------------------
public class ClientEditForm : Form
{
    txtPhone.Text = EditingClient.Phone;
}
}


private void InitializeComponents()
{
    var lblFirst = new Label { Text = "Nombres", AutoSize = false, Height = 18 };
    txtFirstName = new TextBox { Height = 28 };
    var lblLast = new Label { Text = "Apellidos", AutoSize = false, Height = 18 };
    txtLastName = new TextBox { Height = 28 };
    var lblEmail = new Label { Text = "Email", AutoSize = false, Height = 18 };
    txtEmail = new TextBox { Height = 28 };
    var lblPhone = new Label { Text = "Teléfono", AutoSize = false, Height = 18 };
    txtPhone = new TextBox { Height = 28 };


    btnSave = new Button { Text = "Guardar", Width = 100, Height = 34, DialogResult = DialogResult.OK };
    btnCancel = new Button { Text = "Cancelar", Width = 100, Height = 34, DialogResult = DialogResult.Cancel };


    btnSave.Click += BtnSave_Click;


    var layout = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(12), RowCount = 9, ColumnCount = 1 };
    layout.RowStyles.Clear();
    for (int i = 0; i < 8; i++) layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
    layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));


    layout.Controls.Add(lblFirst, 0, 0);
    layout.Controls.Add(txtFirstName, 0, 1);
    layout.Controls.Add(lblLast, 0, 2);
    layout.Controls.Add(txtLastName, 0, 3);
    layout.Controls.Add(lblEmail, 0, 4);
    layout.Controls.Add(txtEmail, 0, 5);
    layout.Controls.Add(lblPhone, 0, 6);
    layout.Controls.Add(txtPhone, 0, 7);


    var panelButtons = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 60, FlowDirection = FlowDirection.RightToLeft, Padding = new Padding(12) };
    panelButtons.Controls.AddRange(new Control[] { btnSave, btnCancel });


    Controls.Add(layout);
    Controls.Add(panelButtons);
}


private void BtnSave_Click(object sender, EventArgs e)
{
    if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
    {
        MessageBox.Show("Nombres y apellidos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        this.DialogResult = DialogResult.None; // evita cerrar el formulario
        return;
    }


    if (IsNew)
    {
        var c = new Client { FirstName = txtFirstName.Text.Trim(), LastName = txtLastName.Text.Trim(), Email = txtEmail.Text.Trim(), Phone = txtPhone.Text.Trim() };
        _main.AddClient(c);
    }
    else
    {
        EditingClient.FirstName = txtFirstName.Text.Trim();
        EditingClient.LastName = txtLastName.Text.Trim();
        EditingClient.Email = txtEmail.Text.Trim();
        EditingClient.Phone = txtPhone.Text.Trim();
        _main.UpdateClient(EditingClient);
    }


    // Si llega aquí, DialogResult.OK y cierre automático
}
}
// ------------------------- PLACEHOLDER FORM (para otros formularios) ------
public class PlaceholderForm : Form
{
    public PlaceholderForm(string title)
    {
        Text = title;
        Width = 700;
        Height = 450;
        InitializeComponents(title);
    }


    private void InitializeComponents(string title)
    {
        var lbl = new Label { Text = $"{title} - Aquí implementaría la interfaz específica.", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 12) };
        Controls.Add(lbl);
    }
}


// ------------------------- ABOUT FORM --------------------------------
public class AboutForm : Form
{
    public AboutForm()
    {
        Text = "Acerca de";
        Width = 400;
        Height = 240;
        StartPosition = FormStartPosition.CenterParent;
        var txt = new TextBox { Multiline = true, ReadOnly = true, Dock = DockStyle.Fill, Text = "Sistema de Facturación - Practica\r\nVersión: 1.0\r\nAutor: Estudiante\r\nDescripcion: Interfaz de ejemplo con menús y formularios.\r\n" };
        Controls.Add(txt);
    }
}
}

