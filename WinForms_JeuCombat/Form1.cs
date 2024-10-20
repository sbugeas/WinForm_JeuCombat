using System.Diagnostics;
using System.Media;
using System.Windows.Forms;
using static WinForms_JeuCombat.Form1;

namespace WinForms_JeuCombat
{
    public partial class Form1 : Form
    {
        //------------------- VARIABLES

        List<Button> characterSelectionButtonList = new List<Button>();
        List<Button> optionButtonList = new List<Button>();

        List<Image> imageList = new List<Image>();

        private bool canChange = true;
        private bool choseCharacter = false;
        public bool choseAction = false;

        private int buttonOffset = 0;

        private Button choiceButton;

        private SoundPlayer sPlayer;
        private SoundPlayer mSoundPlayer;

        public static List<Characters> classList = new List<Characters>();

        //Character types
        public enum CharacterClass
        {
            Damager = 1,
            Healer = 2,
            Tank = 3,
            Assassin = 4,
        }

        //Class wich define a character
        public class Characters
        {
            public CharacterClass characterClass;
            public string name;
            public int curHealth;
            public int maxHealth;
            public int damage;
            public bool isPoisoned;
            public ActionChoice action;

            public Image idle_frame;
            //public Image attack_frame_1;
            //public Image attack_frame_2;
            //public Image spell_frame_1;
            //public Image spell_frame_2;

            //Base constructor
            public Characters(CharacterClass characterClass, string name, int curHealth, int maxHealth, int damage, ActionChoice action, bool isPoisoned)
            {
                this.characterClass = characterClass;
                this.name = name;
                this.curHealth = curHealth;
                this.maxHealth = maxHealth;
                this.damage = damage;
                this.isPoisoned = isPoisoned;
                this.action = action;

                //GET IMAGES
                this.idle_frame = Image.FromFile($"./Images/{name}/{name}Idle.png");
                //this.attack_frame_1 = Image.FromFile($"./Images/{name}/{name}Attack_1.png");
                //this.attack_frame_2 = Image.FromFile($"./Images/{name}/{name}Attack_2.png");
                //this.spell_frame_1 = Image.FromFile($"./Images/{name}/{name}Spell_1.png");
                //this.spell_frame_2 = Image.FromFile($"./Images/{name}/{name}Spell_2.png");
            }

            // Copy constructor
            public Characters(Characters characterToCopy)
            {
                characterClass = characterToCopy.characterClass;
                name = characterToCopy.name;
                curHealth = characterToCopy.curHealth;
                maxHealth = characterToCopy.maxHealth;
                damage = characterToCopy.damage;
                action = characterToCopy.action;
                idle_frame = characterToCopy.idle_frame;
                //attack_frame_1 = characterToCopy.attack_frame_1;
                //attack_frame_2 = characterToCopy.attack_frame_2;
                //spell_frame_1 = characterToCopy.spell_frame_1;
                //spell_frame_2 = characterToCopy.spell_frame_2;
            }

            //Inflict damage to character
            public void TakeDamage(int _damage)
            {
                int res = curHealth - damage;
                if (res < 0) { res = 0; }
                curHealth = res;
            }

            public void Poisoned(int damagePtn)
            {
                curHealth -= damagePtn;
                isPoisoned = true;
            }
        }

        //Possible actions
        public enum ActionChoice
        {
            Attack = 1,
            Defend = 2,
            Spell = 3,
        }

        //--------------------- FIN VARIABLES



        public Form1()
        {
            InitializeComponent();//Start the WinForm

            //Load the sounds and songs (main theme)
            sPlayer = new SoundPlayer("./Sounds/8-Bit_FightingGame_Music.wav");
            sPlayer.Load();
            //Here too (sound effect)
            mSoundPlayer = new SoundPlayer("./Sounds/Game_Start.wav");
            mSoundPlayer.Load();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Get half of screen height and width + half of button height and width to find the perfect center of the screen
            PlayButton.Location = new Point((this.Width / 2) - (PlayButton.Width / 2), (this.Height / 2) - (PlayButton.Height / 2));
            QuitButton.Location = new Point((this.Width / 2) - (QuitButton.Width / 2), (this.Height / 2 + 150) - (QuitButton.Height / 2));

            label1.Location = new Point((this.Width / 2) - (label1.Width / 2), 150);

            textBox1.Location = new Point(-1000, 0);

            //Add character choice buttons to list
            characterSelectionButtonList.AddRange(new Button[] { DamagerButton, HealerButton, TankButton, AssasinButton });
            //Set all the images for the buttons
            imageList.AddRange(new List<Image>() { 
                Image.FromFile("./Images/damager_selection.png"),
                Image.FromFile("./Images/healer_selection.png"),
                Image.FromFile("./Images/tank_selection.png"),
                Image.FromFile("./Images/assassin_selection.png")
            });

            //List of all the option buttons to display later
            optionButtonList.AddRange(new Button[] {AttackButton, DefendButton, SpellButton});
        }

        //BUTTON START
        private async void button1_Click(object sender, EventArgs e)
        {
            mSoundPlayer.Play();//Play sound

            //ANimate controls leaving screen
            AnimationClass.BounceFunction(label1, new Point(0, 100), new Point(0, 400), 11);
            AnimationClass.BounceFunction(PlayButton, new Point(0, 300), new Point(0, 500), 11);
            await Task.Delay(100);
            AnimationClass.BounceFunction(QuitButton, new Point(0, 450), new Point(0, 500), 11);

            buttonOffset = 0;//Offset

            await Task.Delay(2000);//Wait 2 seconds

            //Set all character choice buttons position
            foreach (Button button in characterSelectionButtonList)
            {
                button.Size = new Size(356, 496);//Set the button size to the image's
                button.Image = imageList[int.Parse(button.Tag.ToString())-1];//Select image according to button tag
                button.Location = new Point((this.Width / 5 +  buttonOffset) - (button.Width / 2), (this.Height / 2 + 100) - (button.Height / 2));
                buttonOffset += 400;//Add offset between images
            }

            textBox1.Location = new Point((this.Width / 2) - (textBox1.Width / 2), 150);

            await Task.Delay(1000);

            //sPlayer.PlayLooping();//Loops the song selected  (A REMETTRE)

            //Before the game starts
            textBox1.Text += "Choisissez un personnage:\r\n1 - Damager\r\n2 - Healer\r\n3 - Tank\r\n4 - Assasin\r\n";
        }


        //If clicked exit the app
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();//Exit the app
        }

        //If clicked character selection button
        private void characterChoice_Click(object sender, EventArgs e)
        {
            buttonOffset = 100;
            //Move the buttons on the window
            foreach (Button button in optionButtonList)
            {
                button.Location = new Point((this.Width / 3 + buttonOffset) - (button.Width / 2), (this.Height / 2 + 500) - (button.Height / 2));
                buttonOffset += 200;
            }

            Button clickedButton = sender as Button;//Button clicked that sent triggered the event

            MainFunction(textBox1, clickedButton);//Launch main function
        }

        private void actionChoice_Click(object sender, EventArgs e)
        {
            Button cButton = sender as Button;

            Debug.WriteLine($"Clicked button Tag: {cButton.Tag}");

            choiceButton = cButton;

            choseAction = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.TextLength;//Set text start(the first line to show
            textBox1.ScrollToCaret();//Scroll to bottom
        }


        //Here ends the form section, no more Form controls (buttons, label, textbox ect...)
        //The following code is the logic of the game
        //
        //
        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<------------------------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //
        //
        //
        //Big chunk of code ahead : 
        

        public void MainFunction(TextBox tBox, Button playerSelectionButton) //here, button = character selection button
        {
            //--------- INITIALISATION -----------
            bool isEnd = false;

            Random rnd = new Random();

            Characters damager = new Characters(CharacterClass.Damager, "Damager", 3, 3, 2, ActionChoice.Defend, false);
            Characters healer = new Characters(CharacterClass.Healer, "Healer", 4, 4, 1, ActionChoice.Defend, false);
            Characters tank = new Characters(CharacterClass.Tank, "Tank", 5, 5, 1, ActionChoice.Defend, false);
            Characters assassin = new Characters(CharacterClass.Assassin, "Rogue", 3, 3, 1, ActionChoice.Defend, false);

            classList = new List<Characters> { damager, healer, tank, assassin };
            //------------------------------------

            //Initial sprites placement (characters selected)
            PlayerBox.Location = new Point((this.Width / 2 - 200) - (PlayerBox.Width / 2), (this.Height / 2 + 300) - (PlayerBox.Height / 2));
            ComputerBox.Location = new Point((this.Width / 2 + 200) - (ComputerBox.Width / 2), (this.Height / 2 + 300) - (ComputerBox.Height / 2));

            //Player's choice
            tBox.Text += ("Choisissez un personnage:\r\n1 - Damager\r\n2 - Healer\r\n3 - Tank\r\n4 - Rogue\r\n");
            Characters playerCharacter = PlayerChooseCharacter(tBox, playerSelectionButton, PlayerBox);

            //Display character choice
            tBox.Text += $"\r\nJoueur : {playerCharacter.name}";

            //AI's choice
            Characters AICharacter = new Characters(AIChooseCharacter(ComputerBox));

            //Display character choice
            tBox.Text += $"\r\nAI : {AICharacter.name}";

            //Display health
            DisplayHealth(playerCharacter, AICharacter, tBox);


            //------------- BOUCLE DU JEU  ----------------
            while (!isEnd)
            {
                Debug.WriteLine(choseAction);
                while (!choseAction)
                {
                    Application.DoEvents();//Does not freeze the app waiting for the user input
                }

                choseAction = false;

                //Choix action joueur
                PlayerChooseAction(playerCharacter, tBox, choiceButton, PlayerBox);

                //Choix action IA
                AIChooseAction(AICharacter, ComputerBox);

                //Combat (round)
                Fight(playerCharacter, AICharacter, tBox);

                //On affiche l'�tat du jeu
                DisplayHealth(playerCharacter, AICharacter, tBox);

                //Conditions de fin
                isEnd = isEndGame(playerCharacter, AICharacter, tBox);

            }
        }

        //---------------------------------------------


        //Fonction combat appel� � chaque tour
        static void Fight(Characters player, Characters ai, TextBox tBox)
        {
            //Si cible empoisonn�e au tour pr�c = - 1 HP et on retire empoisonnement
            if (isPoisoned(player))
            {
                tBox.Text += ("\r\nPoison : - 1 HP"); //pour test
                player.TakeDamage(1);
                Poisoned(player, false);
            }
            else if (isPoisoned(ai))
            {
                tBox.Text += ("\r\nPoison : - 1 HP"); //pour test
                ai.TakeDamage(1);
                Poisoned(ai, false);

            }

            //Display
            ShowPlayerAction(player.action, tBox);
            ShowAIAction(ai.action, tBox);

            //Play
            PlayAction(player, ai, true, tBox);
            PlayAction(ai, player, false, tBox);

        }

        //Fonction jouant l'action
        static void PlayAction(Characters actionPlayer, Characters otherPlayer, bool isPlayer, TextBox tBox)
        {
            //GET ACTIONS
            ActionChoice actionPlayerChoice = actionPlayer.action;
            ActionChoice otherPlayerChoice = otherPlayer.action;

            if (actionPlayerChoice == ActionChoice.Spell) //SPELL
            {
                if (actionPlayer.name == "Healer") //HEAL
                {
                    Heal(actionPlayer, tBox);
                }
                else if (actionPlayer.name == "Rogue") //Dagues empoisonn�es
                {
                    //Empoisonne : - 1 HP au prochain tour
                    Poisoned(otherPlayer, true);

                    tBox.Text += ("\r\nPoisoned attack : - 1 HP | Poisoned state"); //pour test

                    //Si cible ne d�fend pas : - 1ptn de d�gat sur le moment
                    if (otherPlayerChoice != ActionChoice.Defend)
                    {
                        otherPlayer.TakeDamage(1);
                    }
                }
                else if (actionPlayer.name == "Tank") //POWERFULL ATTACK
                {
                    //Spell effect (powerfull att)
                    int boostedDamage = actionPlayer.damage + 1;
                    actionPlayer.TakeDamage(1);

                    //OTHER RAGE
                    if ((otherPlayer.characterClass == CharacterClass.Damager) && (otherPlayerChoice == ActionChoice.Spell))
                    {
                        otherPlayer.TakeDamage(boostedDamage);
                        actionPlayer.TakeDamage(boostedDamage);

                    }
                    else if (otherPlayerChoice == ActionChoice.Defend) //OTHER DEFEND
                    {
                        otherPlayer.TakeDamage(boostedDamage - 1);
                    }
                    else  //REST (Attack, Heal, powerfull attack...)
                    {
                        otherPlayer.TakeDamage(boostedDamage);
                    }

                }
            }
            else if (actionPlayerChoice == ActionChoice.Attack) //ATTACK
            {
                //Cas o� l'autre fait rage (damager)
                if ((otherPlayer.characterClass == CharacterClass.Damager) && (otherPlayerChoice == ActionChoice.Spell))
                {
                    otherPlayer.TakeDamage(actionPlayer.damage);
                    actionPlayer.TakeDamage(actionPlayer.damage);
                }
                else if (otherPlayerChoice == ActionChoice.Defend) //Cas o� l'autre d�fend
                {
                    return;
                }
                else //le reste (attaque, heal, powerfull attack etc...)
                {
                    otherPlayer.TakeDamage(actionPlayer.damage);
                }
            }
        }


        //Choix action joueur
        static void PlayerChooseAction(Characters player, TextBox tBox, Button button, PictureBox plrBox)
        {
            int action_player_choice = 0;

            tBox.Text += ("\r\nChoisissez une action:\r\n1 - Attack\r\n2 - Defend\r\n3 - Spell");

            action_player_choice = int.Parse(button.Tag.ToString());

            player.action = (ActionChoice)action_player_choice;

            //----------------------------------------------------------------------------------------------
            AnimationClass.CharacterAnim(plrBox, 1, player.action);
        }


        //Choix d'action IA
        static async void AIChooseAction(Characters ai, PictureBox compBox)
        {
            Random rand = new Random();
            int choiceNb = Enum.GetValues(typeof(ActionChoice)).Length;

            ai.action = (ActionChoice)rand.Next(1, choiceNb + 1);

            await Task.Delay(500);

            //----------------------------------------------------------------------------------------------
            AnimationClass.CharacterAnim(compBox, -1, ai.action);
        }

        
        public Characters PlayerChooseCharacter(TextBox tBox, Button playerChoiceButton, PictureBox plrBox)
        {
            int character_player_choice = 1;

            //If tag not null
            if (playerChoiceButton.Tag != null) 
            {
                //Get + conversion
                int.TryParse(playerChoiceButton.Tag.ToString(), out character_player_choice);

                //Security(if tag not correct)
                if (character_player_choice < 1 || character_player_choice > classList.Count)
                {
                    character_player_choice = 1;
                }
            }

            //Buttons remove (card and select for each)
            this.Controls.Remove(DamagerButton);
            this.Controls.Remove(HealerButton);
            this.Controls.Remove(TankButton);
            this.Controls.Remove(AssasinButton);

            //Get player's choice
            Characters _playerChoice = new Characters(classList[character_player_choice - 1]);

            //Update player sprite (Idle)
            plrBox.Image = _playerChoice.idle_frame;

            //Return player's choice
            return classList[character_player_choice - 1];

        }
        

        //Choix personnage IA
        public Characters AIChooseCharacter(PictureBox compBox)
        {
            Random rand = new Random();
            int rand_index = rand.Next(0, classList.Count);

            //Get AI choice
            Characters _aiCharacter = new Characters(classList[rand_index]);
            
            //Update AI sprite (Idle)
            compBox.Image = _aiCharacter.idle_frame;

            //Return AI choice
            return _aiCharacter;
        }


        //D�tecte fin de jeu
        static bool isEndGame(Characters playerCharacter, Characters aiCharacter, TextBox tBox)
        {
            //Conditions de fin
            bool playerIsDead =playerCharacter.curHealth <= 0;
            bool AIisDead = aiCharacter.curHealth <= 0;

            if (playerIsDead && AIisDead)
            {
                tBox.Text += ("\r\nEgalit� !");
                return true;
            }
            else if (AIisDead)
            {
                tBox.Text += ("\r\nLe joueur a gagn� !");
                return true;
            }
            else if (playerIsDead)
            {
                tBox.Text += ("\r\nl'AI a gagn� !");
                return true;
            }
            else return false;
        }

        //----- Fonction spell
        static void Heal(Characters charact, TextBox tBox)
        {
            int _health = (int)charact.curHealth + 2;
            //V�rifie qu'on ne d�passe pas la sant� max
            charact.curHealth = Math.Min(_health, charact.curHealth);
        }

        //---- Fonction affichage
        static void ShowPlayerAction(ActionChoice action, TextBox tBox)
        {
            tBox.Text += ($"\r\nPlayer choice : {action.ToString()}");
        }

        static void ShowAIAction(ActionChoice action, TextBox tBox)
        {
            tBox.Text += ($"\r\nAI choice : {action.ToString()}");
        }

        static void DisplayHealth(Characters player, Characters ai, TextBox tBox)
        {
            tBox.Text += $"\r\nHP joueur : {player.curHealth}/{player.maxHealth}";
            tBox.Text += $"\r\nHP IA : {ai.curHealth}/{ai.maxHealth}";
        }

        static void Poisoned(Characters character, bool b)
        {
            character.isPoisoned = b;
        }

        static bool isPoisoned(Characters character)
        {
            return (bool)character.isPoisoned;
        }

    }
}
