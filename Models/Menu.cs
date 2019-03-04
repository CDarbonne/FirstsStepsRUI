namespace FirstsStepsRUI.Models
{
    public class Menu
    {
        public MenuOption Option { get; private set; }

        public string Name
        {
            get
            {
                string name;
                switch (Option)
                {
                    default:
                        name = Option.ToString();
                        break;
                }

                return name;
            }            
        }

        public Menu(MenuOption option)
        {
            Option = option;
        }

        //TODO: Switch to property, if possible
        public override string ToString()
        {
            string name;
            switch (Option)
            {
                default:
                    name = Option.ToString();
                    break;
            }

            return name;
        }
        
    }

    public enum MenuOption
    {
        Login,
        User,
        Placeholder
    }
}
