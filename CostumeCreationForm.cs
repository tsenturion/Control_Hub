using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Control_Hub
{
    public partial class CostumeCreationForm : Form
    {
        private List<BodyPart> bodyParts;
        private Costume currentCostume;

        public CostumeCreationForm()
        {
            InitializeComponent();
            InitializeBodyParts();
            InitializeButtons();
            currentCostume = new Costume();
        }

        private void InitializeButtons()
        {
            // Кнопка для добавления части тела
            Button addBodyPartButton = new Button();
            addBodyPartButton.Text = "Добавить часть тела";
            addBodyPartButton.Location = new Point(10, 10);
            addBodyPartButton.Click += AddBodyPartButton_Click;
            this.Controls.Add(addBodyPartButton);

            // Кнопка для сохранения костюма
            Button saveButton = new Button();
            saveButton.Text = "Сохранить костюм";
            saveButton.Location = new Point(120, 10);
            saveButton.Click += SaveCostumeButton_Click;
            this.Controls.Add(saveButton);

            // Кнопка для загрузки костюма
            Button loadButton = new Button();
            loadButton.Text = "Загрузить костюм";
            loadButton.Location = new Point(230, 10);
            loadButton.Click += LoadCostumeButton_Click;
            this.Controls.Add(loadButton);

            // Кнопка для закрытия окна
            Button closeButton = new Button();
            closeButton.Text = "Закрыть";
            closeButton.Location = new Point(340, 10);
            closeButton.Click += CloseButton_Click;
            this.Controls.Add(closeButton);
        }

        private void AddBodyPartButton_Click(object sender, EventArgs e)
        {
            // Логика добавления части тела...
        }
        private void InitializeBodyParts()
        {
            bodyParts = new List<BodyPart>
            {
                new BodyPart { Name = "Right Hand" },
                new BodyPart { Name = "Left Hand" },
                new BodyPart { Name = "Right Leg" },
                new BodyPart { Name = "Left Leg" },
                new BodyPart { Name = "Torso" },
                new BodyPart { Name = "Head" }
            };
        }

        private void SaveCostumeButton_Click(object sender, EventArgs e)
        {
            SaveCostumeToFile();
        }

        private void SaveCostumeToFile()
        {
            string json = JsonConvert.SerializeObject(currentCostume, Formatting.Indented);
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Costumes", $"costume_{currentCostume.CostumeNumber}.json");
            File.WriteAllText(filePath, json);
            MessageBox.Show("Костюм сохранен успешно.");
        }

        private void LoadCostumeButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Costumes");

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadCostumeFromFile(openFileDialog.FileName);
            }
        }

        private void LoadCostumeFromFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            currentCostume = JsonConvert.DeserializeObject<Costume>(json);
            UpdateCostumeUI();
            MessageBox.Show("Костюм загружен успешно.");
        }

        private void UpdateCostumeUI()
        {
            // Здесь должен быть код для обновления интерфейса, чтобы отобразить загруженный костюм
            // Например, вы можете обновить списки, текстовые поля или другие элементы управления
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (currentCostume.CostumeNumber == 0)
            {
                // Если костюм не сохранен, показываем предупреждение
                if (MessageBox.Show("Костюм не сохранен. Закрыть без сохранения?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            this.Close();
        }
    }

    public class Costume
    {
        public int CostumeNumber { get; set; }
        public List<BodyPart> BodyParts { get; set; }
    }

    public class BodyPart
    {
        public string Name { get; set; }
        public int PortNumber { get; set; }
        public LedStrip FrontLedStrip { get; set; }
        public LedStrip BackLedStrip { get; set; }
    }

    public class LedStrip
    {
        public int LedCount { get; set; }
        public List<LedPosition> LedPositions { get; set; }
    }

    public class LedPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}