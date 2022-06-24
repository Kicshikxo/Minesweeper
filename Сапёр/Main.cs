using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using System.IO;

namespace Сапёр
{
    public partial class Main : Form
    {
        // Переменная изображения и графики для него
        private Bitmap image;
        private Graphics graphics;

        /// <summary>
        /// Размер блока
        /// </summary>
        private int cellSize = 40;

        // Количество бомб
        private int bombs = 10;

        // Количество оставшихся бомб, которое видит пользователь
        private int playerBombsLeft = 0;

        // Переменная определяющая то, завершена игра или нет
        private bool gameOver = false;

        // Счётчик потраченного времени
        private int spentTime = 0;

        /// <summary>
        /// Размер поля по горизонтали
        /// </summary>
        private int xSize = 8;
        /// <summary>
        /// Размер поля по вертикали
        /// </summary>
        private int ySize = 8;

        // Переменная рандома
        private Random random = new Random();

        // Окно настроек
        private Settings settings;

        /// <summary>
        /// Список всех смещений соседних блоков, относительно точки
        /// </summary>
        private readonly int[][] blocksAround = new int[9][] {
            new int[2] {-1,-1 },
            new int[2] {-1, 0 },
            new int[2] {-1, 1 },

            new int[2] { 0,-1 },
            new int[2] { 0, 0 },
            new int[2] { 0, 1 },

            new int[2] { 1,-1 },
            new int[2] { 1, 0 },
            new int[2] { 1, 1 }
        };
        //private readonly List<List<int>> blocksAround = new List<List<int>>(9) {
        //    new List<int> {-1,-1 },
        //    new List<int> {-1, 0 },
        //    new List<int> {-1, 1 },

        //    new List<int> { 0,-1 },
        //    new List<int> { 0, 0 },
        //    new List<int> { 0, 1 },

        //    new List<int> { 1,-1 },
        //    new List<int> { 1, 0 },
        //    new List<int> { 1, 1 }
        //};

        /// <summary>
        /// Главное игровое поле блоков
        /// </summary>
        private List<List<Block>> field = new List<List<Block>> { };

        // Переменные звука
        private SoundPlayer openBlockSound = new SoundPlayer();
        private SoundPlayer explosionSound = new SoundPlayer();
        private SoundPlayer setFlagSound = new SoundPlayer();
        private SoundPlayer winSound = new SoundPlayer();

        // Коллекция шрифтов
        private PrivateFontCollection fontCollection;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Создание основного изображения
            image = new Bitmap(xSize * cellSize, ySize * cellSize);

            // Вывод изображения в picturebox
            GamePictureBox.Image = image;

            // Получение графики из изображения
            graphics = Graphics.FromImage(image);

            // Установка значений для оптимизации отрисовки
            graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;

            // Присваивание звуков в их переменные
            openBlockSound.Stream = Properties.Resources.open_block;
            explosionSound.Stream = Properties.Resources.explosion;
            setFlagSound.Stream = Properties.Resources.set_flag;
            winSound.Stream = Properties.Resources.win;

            // Получение шрифта из ресурсов и установка его в нужные лейблы
            fontCollection = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.DigitalCyrillic))
            {
                IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                byte[] fontdata = new byte[fontStream.Length];
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                fontCollection.AddMemoryFont(data, (int)fontStream.Length);
                Marshal.FreeCoTaskMem(data);
            }
            BombsLeftLabel.Font = new Font(fontCollection.Families[0], 24);
            TimerLabel.Font = new Font(fontCollection.Families[0], 24);

            // Рестарт игры
            Restart();
        }

        /// <summary>
        /// Рестарт игры
        /// </summary>
        private void Restart()
        {
            // Возвращение переменных в их начальный вид
            SmileButton.Image = Properties.Resources.smile;
            gameOver = false;
            playerBombsLeft = bombs;
            spentTime = 0;

            // Остановка таймера
            GameTimer.Stop();

            // Обнуление всех счётчиков
            BombsLeftLabel.Text = "000";
            TimerLabel.Text = "000";

            // Создание нового поля и полная его отрисовка
            CreateField();
            FullRedraw();
        }

        /// <summary>
        /// Создание поля
        /// </summary>
        private void CreateField()
        {
            // Очистка текущего поля
            field.Clear();

            // Проход по полю и добавление в него пустых блоков
            for (int y = 0; y < ySize; y++)
            {
                field.Add(new List<Block> { });
                for (int x = 0; x < xSize; x++)
                {
                    field[y].Add(new Block(x, y, cellSize, GamePictureBox, graphics));
                }
            }
        }

        /// <summary>
        /// Полная перерисовка изображения
        /// </summary>
        public void FullRedraw()
        {
            // Очистка изображения
            graphics.Clear(Color.FromArgb(22, 22, 22));

            // Вызов у каждого блока поля метода отрисовки
            foreach (List<Block> blocksList in field)
            {
                foreach (Block block in blocksList)
                {
                    block.Draw();
                }
            }
        }

        /// <summary>
        /// Получение блока в поле по его координатам
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Block GetBlock(int x, int y)
        {
            return field[y][x];
        }

        /// <summary>
        /// Определение находятся ли координаты в границах размера поля
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool WithinField(int x, int y)
        {
            return x >= 0 && x < xSize && y >= 0 && y < ySize;
        }

        /// <summary>
        /// Заполнение поля бомбами и цифрами
        /// </summary>
        /// <param name="clickX"></param>
        /// <param name="clickY"></param>
        private void FillBombs(int clickX, int clickY)
        {
            // Количество добавленных бомб
            int bombsCount = 0;

            // Повторение пока количество бомб не будет равно количеству необходимых бомб
            while (bombsCount < bombs)
            {
                // Получение рандомных координат для новой бомбы
                int newBombX = random.Next(0, xSize);
                int newBombY = random.Next(0, ySize);

                // Если бомба по таким координатам уже есть, то создать новую бомбу
                if (GetBlock(newBombX, newBombY).type == "bomb") continue;

                // Переменная для определения подходил ли эта бомба
                bool notSuitable = false;

                // Определение находится ли новая бомба вблизи первого нажатия, если да, то создать новую бомбу
                foreach (int[] point in blocksAround)
                {
                    if (newBombX + point[0] == clickX && newBombY + point[1] == clickY)
                    {
                        notSuitable = true;
                        break;
                    }
                }
                if (notSuitable) continue;

                // Присваивание блоку по координатам тип бомбы
                GetBlock(newBombX, newBombY).type = "bomb";

                // Увеличение счётчика бомб
                bombsCount++;
            }

            // Заполнение поля цифрами
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    if (GetBlock(x, y).type != "bomb")
                    {
                        // Подсчёт количества бомб вокруг
                        int bombsAround = 0;
                        foreach (int[] point in blocksAround)
                        {
                            int offsetX = x + point[0];
                            int offsetY = y + point[1];
                            if (WithinField(offsetX, offsetY) && GetBlock(offsetX, offsetY).type == "bomb")
                                bombsAround++;
                        }

                        // Установка значения равного количеству бомб вокруг
                        if (bombsAround > 0)
                            GetBlock(x, y).type = "block-" + bombsAround;
                        else GetBlock(x, y).type = "blank";
                    }
                }
            }
        }

        /// <summary>
        /// Открытие блока по координатам
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void OpenBlock(int x, int y)
        {
            // Получение блока из данных координат
            Block block = GetBlock(x, y);

            // Открытие блока
            block.opened = true;

            // Если открытый блок бомба, то конец игры
            if (block.type == "bomb")
            {
                // Установка кликнутой бомбе типа бомбы по которой кликнуле и завершить игру проигрышем
                block.type = "bomb-clicked";
                block.Draw();
                GameOver();
            }

            // Если открытый блок пустой, то открыть все соседние к нему клетки
            else if (block.type == "blank" && !gameOver)
            {
                foreach (int[] point in blocksAround)
                {
                    int offsetX = x + point[0];
                    int offsetY = y + point[1];
                    if (WithinField(offsetX, offsetY) && !GetBlock(offsetX, offsetY).opened)
                        OpenBlock(offsetX, offsetY);
                }
            }
        }

        /// <summary>
        /// Открыть блоки вокруг блока если количество флажков вокруг него равно значению блока
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void OpenAround(int x, int y)
        {
            // Счётчики для подсчёта количества флажкованных блоков, и количества закрытых блоков
            int flaggedBlocksAround = 0;
            int closedBlocksAround = 0;

            // Подсчёт количество флажкованных и закрытых блоков вокруг
            foreach (int[] point in blocksAround)
            {
                int offsetX = x + point[0];
                int offsetY = y + point[1];
                if (WithinField(offsetX, offsetY))
                {
                    if (GetBlock(offsetX, offsetY).flagged)
                        flaggedBlocksAround++;
                    else if (!GetBlock(offsetX, offsetY).opened)
                        closedBlocksAround++;
                }
            }

            // Если количество флажков равно значению блока, то открыть все соседние блока
            if (int.Parse(GetBlock(x, y).type.Last().ToString()) == flaggedBlocksAround)
            {
                foreach (int[] point in blocksAround)
                    if (WithinField(x + point[0], y + point[1]) && !field[y + point[1]][x + point[0]].opened && !field[y + point[1]][x + point[0]].flagged)
                        OpenBlock(x + point[0], y + point[1]);

                // Проиграть звук открытия блока если было что открывать
                if (closedBlocksAround > 0 && !gameOver) openBlockSound.Play();
            }
        }

        // Событие при нажатии
        private void GamePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Продолжить только если игра не закончена
            if (gameOver) return;

            // Получение координат блока из координат нажатия
            int clickX = e.X / cellSize;
            int clickY = e.Y / cellSize;

            // Получение тыкнутого блока по координатам
            Block block = GetBlock(clickX, clickY);

            // Если нажата левая кнопка мышки
            if (e.Button == MouseButtons.Left)
            {
                // Если кликнутый блок открыт и не пустой, то открыть все соседкие блоки
                if (block.opened && block.type != "blank")
                    OpenAround(clickX, clickY);
                else
                {
                    // Если поле пустое, то заполнить его, проиграть звук и запустить таймер
                    if (field[0][0].type == "none")
                    {
                        FillBombs(clickX, clickY);
                        openBlockSound.Play();
                        if (!GameTimer.Enabled) GameTimer.Start();
                        BombsLeftLabel.Text = $"{playerBombsLeft}".PadLeft(3, '0');
                    }

                    // Если блок закрыт и на нём нет флажка, то открыть его
                    if (!block.flagged && !block.opened)
                    {
                        openBlockSound.Play();
                        OpenBlock(clickX, clickY);
                    }
                }
            }

            // Если нажата правая кнопка мыши
            else if (e.Button == MouseButtons.Right)
            {
                // Если блок не открыт и поле заполнено, то установить флажок на тыкнутый блок
                if (!block.opened && GetBlock(0, 0).type != "none")
                {
                    setFlagSound.Play();

                    if (block.flagged) playerBombsLeft++;
                    else playerBombsLeft--;

                    BombsLeftLabel.Text = $"{playerBombsLeft}".PadLeft(3, '0');

                    block.flagged = !block.flagged;
                }
            }
            // Проверка поля на победу
            if (CheckForWin() && !gameOver) Win();
        }

        /// <summary>
        /// Проверка на то, зачищено ли поле
        /// </summary>
        private bool CheckForWin()
        {
            // Счётчик закрытых блоков на поле
            int closedBlocks = 0;

            // Подсчёт закрытых блоковна поле
            foreach (List<Block> blocksList in field)
                foreach (Block block in blocksList)
                    if (!block.opened) closedBlocks++;

            // Если общее количество бомб равно количеству закрытых блоков, то поле зачищено
            return bombs == closedBlocks;
        }

        /// <summary>
        /// Выигрыш
        /// </summary>
        private void Win()
        {
            // Установка переменных в положение при выигрыше
            gameOver = true;
            SmileButton.Image = Properties.Resources.smile_cool;

            // Воспроизведение звука выигрыша
            openBlockSound.Stop();
            winSound.Play();

            // Остановка таймера
            GameTimer.Stop();

            // Обнуление счётчика бомб
            BombsLeftLabel.Text = "000";

            // Установка флажков на все бомбы
            foreach (List<Block> blocksList in field)
                foreach (Block block in blocksList)
                    if (block.type == "bomb") block.flagged = true;
        }

        /// <summary>
        /// Проигрыш
        /// </summary>
        private void GameOver()
        {
            // Установка переменных в положение при проигрыше
            gameOver = true;
            SmileButton.Image = Properties.Resources.smile_sad;

            // Воспроизведение звука проигрыша
            openBlockSound.Stop();
            explosionSound.Play();

            // Остановка таймера
            GameTimer.Stop();

            // Открытие всех закрытых бомб и установка неверных флажков
            foreach (List<Block> blocksList in field)
                foreach (Block block in blocksList)
                {
                    if (block.type == "bomb" && !block.flagged) block.opened = true;
                    if (block.flagged && block.type != "bomb")
                    {
                        block.type = "wrong-flag";
                        block.Draw();
                    }
                }
        }

        // Клик по смайлику
        private void SmileButton_Click(object sender, EventArgs e)
        {
            if (GetBlock(0, 0).type != "none") Restart();
        }

        // Открытие окна настроек
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            // Создание окна настроек
            settings = new Settings();

            // Установка в полях настроек текущих значений
            settings.FieldHeightTextBox.Text = $"{ySize}";
            settings.FieldWidthTextBox.Text = $"{xSize}";
            settings.BombsCountTextBox.Text = $"{bombs}";

            // Создание события обновления поля при нажатии на кнопку Готово в настройках
            settings.DoneButton.Click += ChangeField;

            // Показ окна настроек
            settings.ShowDialog();
        }

        // Изменение иконки кнопки настроек при наведении и отведении мышки на неё
        private void SettingsButton_MouseEnter(object sender, EventArgs e)
        {
            SettingsButton.Image = Properties.Resources.settings_hover;
        }

        private void SettingsButton_MouseLeave(object sender, EventArgs e)
        {
            SettingsButton.Image = Properties.Resources.settings;
        }

        /// <summary>
        /// Изменение размеров поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeField(object sender, EventArgs e)
        {
            // Если поля настроек не пустые, то продолжить
            if (settings.FieldWidthTextBox.Text != "" && settings.FieldHeightTextBox.Text != "")
            {
                // Установка размеров поля из полей настроек
                xSize = Convert.ToInt32(settings.FieldWidthTextBox.Text);
                ySize = Convert.ToInt32(settings.FieldHeightTextBox.Text);

                // Если в поле настроек есть значение бомб, то в количество бомб установить его, иначе расчитать автоматически
                if (settings.BombsCountTextBox.Text != "" && settings.BombsCountTextBox.Text != "0")
                    bombs = Convert.ToInt32(settings.BombsCountTextBox.Text);
                else
                    bombs = Convert.ToInt32(xSize * ySize / 6.4);

                // Если количество бомб больше размеров поля, то выдать ошибку
                if (xSize * ySize - 9 <= bombs)
                    MessageBox.Show("Слишком большое количество бомб", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // Создание нового изображения пол размер нового поля
                    image = new Bitmap(xSize * cellSize, ySize * cellSize);

                    // Вывод изображения в picturebox
                    GamePictureBox.Image = image;

                    // Получение графики из изображения
                    graphics = Graphics.FromImage(image);

                    // Сохранение старого размера окна
                    Size oldSize = Size;

                    // Вычисление нового размера окна
                    Size = new Size(xSize * cellSize + 20, ySize * cellSize + 29 + 50 + 20);

                    // Если размеры окна изменились, то центровать его на экране
                    if (oldSize != Size) CenterToScreen();

                    // Изменение размера панели, хранящей picturebox
                    GamePictureBoxPanel.Size = new Size(xSize * cellSize + 20, ySize * cellSize + 20);

                    // Сброс с лейблов настомного шрифта (ибо оно при ресайзе иногда выдаёт ошибку)
                    BombsLeftLabel.Font = new Font("Microsoft Sans Serif", 24);
                    TimerLabel.Font = new Font("Microsoft Sans Serif", 24);

                    // Изменение положения лейблов
                    BombsLeftLabel.Location = new Point(Size.Width / 4 - 36 + 10 + 5, 9 + 5);
                    TimerLabel.Location = new Point(Size.Width / 2 + Size.Width / 4 - 36 + 10 - 20 , 9 + 5);

                    // Установка кастомного шрифта заново
                    BombsLeftLabel.Font = new Font(fontCollection.Families[0], 24);
                    TimerLabel.Font = new Font(fontCollection.Families[0], 24);

                    // Изменение положения кнопки со смайликом
                    SmileButton.Left = Size.Width / 2 - 20;

                    // Растягивание панели с элементами управления на весь экран
                    MenuPanel.Width = Size.Width;

                    // Рестарт игры
                    Restart();

                    // Закрытие окна
                    settings.Close();
                }
            }
            // Иначе показать ошибку
            else MessageBox.Show("Размеры поля не могут быть пустыми", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Таймер подсчёта времени
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (spentTime < 999) spentTime++;
            TimerLabel.Text = $"{spentTime}".PadLeft(3, '0');
        }

        // Перетаскивание окна
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Capture = false;
            Message m = Message.Create(Handle, 161, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        // Логика для кнопки закрыть
        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseFormButton_MouseEnter(object sender, EventArgs e)
        {
            CloseFormButton.Image = Properties.Resources.close_button_hover;
        }

        private void CloseFormButton_MouseLeave(object sender, EventArgs e)
        {
            CloseFormButton.Image = Properties.Resources.close_button;
        }

        // Логика для кнопки свернуть
        private void MinimizeFormButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MinimizeFormButton_MouseEnter(object sender, EventArgs e)
        {
            MinimizeFormButton.Image = Properties.Resources.minimize_button_hover;
        }

        private void MinimizeFormButton_MouseLeave(object sender, EventArgs e)
        {
            MinimizeFormButton.Image = Properties.Resources.minimize_button;
        }
    }

    /// <summary>
    /// Класс блока игрового поля
    /// </summary>
    public class Block
    {
        public int x, y;
        public int size;

        public string type = "none";

        private PictureBox pictureBox;
        private Graphics graphics;

        private bool Opened = false;
        public bool opened {
            get
            {
                return Opened;
            }
            set {
                Opened = value;
                Draw();
            } 
        }

        private bool Flagged = false;
        public bool flagged
        {
            get
            {
                return Flagged;
            }
            set
            {
                Flagged = value;
                Draw();
            }
        }

        public Block(int x_, int y_, int size_, PictureBox pictureBox_, Graphics graphics_)
        {
            x = x_;
            y = y_;
            size = size_;
            pictureBox = pictureBox_;
            graphics = graphics_;
        }

        public void Draw()
        {
            if (!opened)
            {
                if (flagged)
                {
                    if (type == "wrong-flag") graphics.DrawImage(Properties.Resources.not_flagged_block, x * size, y * size);
                    else graphics.DrawImage(Properties.Resources.flagged_block, x * size, y * size);
                }
                else graphics.DrawImage(Properties.Resources.closed_block, x * size, y * size);
            }

            else if (type == "blank") graphics.DrawImage(Properties.Resources.blank_block, x * size, y * size);

            else if (type == "block-1") graphics.DrawImage(Properties.Resources.block_1, x * size, y * size);
            else if (type == "block-2") graphics.DrawImage(Properties.Resources.block_2, x * size, y * size);
            else if (type == "block-3") graphics.DrawImage(Properties.Resources.block_3, x * size, y * size);
            else if (type == "block-4") graphics.DrawImage(Properties.Resources.block_4, x * size, y * size);
            else if (type == "block-5") graphics.DrawImage(Properties.Resources.block_5, x * size, y * size);
            else if (type == "block-6") graphics.DrawImage(Properties.Resources.block_6, x * size, y * size);
            else if (type == "block-7") graphics.DrawImage(Properties.Resources.block_7, x * size, y * size);
            else if (type == "block-8") graphics.DrawImage(Properties.Resources.block_8, x * size, y * size);
            
            else if (type == "bomb") graphics.DrawImage(Properties.Resources.not_clicked_bomb_block, x * size, y * size);
            else if (type == "bomb-clicked") graphics.DrawImage(Properties.Resources.clicked_bomb_block, x * size, y * size);

            else graphics.DrawImage(Properties.Resources.blank_block, x * size, y * size);

            pictureBox.Invalidate();
        }
    }
}
