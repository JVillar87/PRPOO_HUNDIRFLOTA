namespace HundirLaFlota.Presentacion;

public static class ArteAscii
{
    public static void MostrarLogo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
  _    _ _    _ _   _ _____ _____ _____    _          
 | |  | | |  | | \ | |  __ \_   _|  __ \  | |         
 | |__| | |  | |  \| | |  | || | | |__) | | |     __ _ 
 |  __  | |  | | . ` | |  | || | |  _  /  | |    / _` |
 | |  | | |__| | |\  | |__| || |_| | \ \  | |___| (_| |
 |_|  |_|\____/|_| \_|_____/_____|_|  \_\ |______\__,_|
                                                       
                ______ _      ____ _______          
               |  ____| |    / __ \__   __|/ \        
               | |__  | |   | |  | | | |  / ^ \       
               |  __| | |   | |  | | | | / ___ \      
               | |    | |___| |__| | | |/ /   \ \     
               |_|    |______\____/  |_/_/     \_\    
        ");
        Console.ResetColor();
    }

    public static void MostrarBarcoDecorativo()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
                   |    |    |
                  )_)  )_)  )_)
                 )___))___))___)\
                )____)____)_____)\\
              _____|____|____|____\\\__
     ---------\                   /---------
      ^^^^^ ^^^^^^^^^^^^^^^^^^^^^^^^^^^
        ");
        Console.ResetColor();
    }

    public static void MostrarVictoria()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
  __      _______ _____ _______ ____  _____  _____          
  \ \    / /_   _/ ____|__   __/ __ \|  __ \|_   _|   /\    
   \ \  / /  | || |       | | | |  | | |__) | | |    /  \   
    \ \/ /   | || |       | | | |  | |  _  /  | |   / /\ \  
     \  /   _| || |____   | | | |__| | | \ \ _| |_ / ____ \ 
      \/   |_____\_____|  |_|  \____/|_|  \_\_____/_/    \_\
        ");
        Console.ResetColor();
    }

    public static void MostrarExplosion()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@"
               _ ._  _ , _ ._
             (_ ' ( `  )_  .__)
           ( (  (    )   `)  ) _)
          (__ (_   (_ . _) _) ,__)
              `~~`\ ' . /`~~`
                   | f |
                   | i |
                   | r |
                   | e |
        ");
        Console.ResetColor();
    }
}