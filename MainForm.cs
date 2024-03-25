using System;
using System.Drawing;
using System.Windows.Forms;

namespace Control_Hub
{
    public partial class MainForm : Form
    {
        private Button scenarioButton;
        private Button musicButton;
        private Button costumeButton;

        public MainForm()
        {
            InitializeComponent();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            // Создаем кнопки
            scenarioButton = new Button();
            musicButton = new Button();
            costumeButton = new Button();

            // Устанавливаем свойства кнопок
            scenarioButton.Text = "Сценарий";
            musicButton.Text = "Музыка";
            costumeButton.Text = "Костюмы";

            // Добавляем обработчики событий
            scenarioButton.Click += ScenarioButton_Click;
            musicButton.Click += MusicButton_Click;
            costumeButton.Click += CostumeButton_Click;

            // Добавляем кнопки на форму
            this.Controls.Add(scenarioButton);
            this.Controls.Add(musicButton);
            this.Controls.Add(costumeButton);

            scenarioButton.Location = new Point(10, 10);
            musicButton.Location = new Point(95, 10); 
            costumeButton.Location = new Point(180, 10); 
        }

        private void ScenarioButton_Click(object sender, EventArgs e)
        {
            ShowContextMenu(scenarioButton);
        }

        private void MusicButton_Click(object sender, EventArgs e)
        {
            ShowContextMenu(musicButton);
        }

        private void CostumeButton_Click(object sender, EventArgs e)
        {
            ShowContextMenu(costumeButton);
        }

        private void ShowContextMenu(Button button)
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // Добавляем пункты меню в зависимости от кнопки
            if (button == scenarioButton)
            {
                contextMenu.Items.Add(new ToolStripMenuItem("Создать сценарий", null, ScenarioCreate_Click));
                contextMenu.Items.Add(new ToolStripMenuItem("Воспроизвести сценарий на экране", null, ScenarioPlayOnScreen_Click));
                contextMenu.Items.Add(new ToolStripMenuItem("Воспроизвести сценарий на костюмах и экране", null, ScenarioPlayOnCostumes_Click));
                contextMenu.Items.Add(new ToolStripMenuItem("Передача данных на костюмы", null, ScenarioDataToCostumes_Click));
                contextMenu.Items.Add(new ToolStripMenuItem("Сформировать архив сценария", null, ScenarioArchive_Click));
                contextMenu.Items.Add(new ToolStripMenuItem("Тест костюмов", null, ScenarioTestCostumes_Click));
            }
            else if (button == musicButton)
            {
                contextMenu.Items.Add(new ToolStripMenuItem("Редактор паттернов", null, MusicEditor_Click));
                contextMenu.Items.Add(new ToolStripMenuItem("Загрузить файл музыки", null, MusicLoadFile_Click));
            }
            else if (button == costumeButton)
            {
                contextMenu.Items.Add(new ToolStripMenuItem("Создать костюм", null, CostumeCreate_Click));
            }

            // Отображаем контекстное меню
            contextMenu.Show(button, new System.Drawing.Point(0, button.Height));
        }

        // Обработчики для пунктов меню
        private void ScenarioCreate_Click(object sender, EventArgs e)
        {
            // Логика для "Создать сценарий"
        }

        private void ScenarioPlayOnScreen_Click(object sender, EventArgs e)
        {
            // Логика для "Воспроизвести сценарий на экране"
        }

        private void ScenarioPlayOnCostumes_Click(object sender, EventArgs e)
        {
            // Логика для "Воспроизвести сценарий на костюмах и экране"
        }
        

        private void MusicEditor_Click(object sender, EventArgs e)
        {
            // Логика для "Редактор паттернов"
        }

        private void MusicLoadFile_Click(object sender, EventArgs e)
        {
            // Логика для "Загрузить файл музыки"
        }

        private void CostumeCreate_Click(object sender, EventArgs e)
        {
            // Создание и показ формы создания костюмов
            using (CostumeCreationForm costumeCreationForm = new CostumeCreationForm())
            {
                costumeCreationForm.ShowDialog();
            }
        }

        private void ScenarioDataToCostumes_Click(object sender, EventArgs e)
        {
            // Логика для "Передача данных на костюмы"
        }

        private void ScenarioArchive_Click(object sender, EventArgs e)
        {
            // Логика для "Сформировать архив сценария"
        }

        private void ScenarioTestCostumes_Click(object sender, EventArgs e)
        {
            // Логика для "Тест костюмов"
        }
    }
}