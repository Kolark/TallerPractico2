# TallerPractico 2 Readme

Para empezar a explicar nuestra implementación: Estas son unas Clases que tenemos 

# Clases  : 
Critter, Skill
AttackSkill : Skill,SupportSkill : Skill
DefenseUp : SupportSkill,AttackUp : SupportSkill,SpeedDown : SupportSkill
# ClasesScriptableObject : Heredan de Scriptable Object
CritterScriptableObject,SkillScriptableObject
AttackSkillScriptableObject : SkillScriptableObject, SupportSkillScriptableObject : SkillScriptableObject
DefenseUpScriptableObject : SupportSkillScriptableObject,AttackUpScriptableObject : SupportSkillScriptableObject,SpeedDownScriptableObject : SupportSkillScriptableObject

Las clases son aquellas que desarrollamos en el anterior taller de Scripting, con un pequeño cambio el constructor recibe como parámetro claseScriptableObject de esta manera por ejemplo la clase Critter recibe en el constructor un párametro tipo CritterScriptableObject, la razón de hacer esta diferencia es que si haciamos la clase Critter herede de ScriptableObject, daba problemas ya que ambos jugadores poseian la misma referencia a un critter cuando deberian ser diferentes referencias. Las ClasesScriptableObject solo poseen los atributos necesarios para que los constructores de las Clases correspondientes asignen los valores. Otra cosa importante a mencionar es que las clases de ClasesScriptableObject poseen un método llamado GetObject(); , ese método retorna un nuevo objeto de la clase correspondiente y como la clase correspondiente recibe un claseScriptableObject. 
Para ejemplificar tomemos a Critter y CritterScriptableObject:

 public Critter(CritterScriptableObject critter){} // Constructor de Critter
 
 public Critter getObject(){return new Critter(this);} // Método de CritterScriptableObject
 
 En resumén a lo dicho anteriormente, las ClasesScriptableObject sirven como un "template" del cual se pueden generar objetos como lo son las Clases.
 
 Ahora para hablar del GameReferee, este implementa la interfaz llamada ICommand, esta interfaz posee un unico método void Execute(int n), la razón por la que este implementa esta interfaz es debido a que el método Execute sera la decisión hecha por el jugador en su turno y "n" el skill realizado. Fue pensado de la siguiente manera, el arbitro se encarga de decirle a cada User que le toca su turno, por tanto a cada User le pasa un objeto tipo ICommand(refiriendose al Gamereferee que la implementa) a través del método SetCommand, el user la guarda ya que posee un atributo para esto, luego el siguiente paso es esperar a que el User decida que hacer, osea esperar a que llamé el método Execute del objeto tipo ICommand que tiene guardado, cuando se decide y llama al método Execute(int n), el Gamereferee se encarga de realizar la logica en Execute(int n) para que se de la interacción entre los Critters que estan peleando, por ultimo se encarga de decirle otra vez a que User le toca el turno, repitiendose el ciclo hasta que uno de los 2 jugadores gané.
 
Player y EnemyBot Heredan de user, su unico trabajo es hacer un Override al método SetCommand(), el sobreescribir ese método es importante, debido a que un humano se comunica con los Botones del Ui correspondientes, mientras que con un bot no hay manera de hacer eso, por ello cuando el EnemyBot sobreescribe el método este mismo responde que su decisión en 2 segundos.(2 segundos debido a que se usa una corrutina, este es un detalle para que la respuesta del EnemyBot no sea instantanea). Debido a que GameReferee hace referencia a User y no a EnemyBot ó Player directamente y a la manera en como se actualiza la interfaz gráfica, nuestra implementación permite que 2 jugadores humanos jueguen en contra, o que 2 bots peleen entre sí. 

User es la clase padre de Player y EnemyBot, esta clase posee una lista publica de CritterScriptableObject, el User usa el método de GetObject() en CritterScriptableObject para obtener los Critters y guardarlos en una lista llamada crittersInventory, luego de esta lista se toman los 3 primeros Critters y se añaden a un Queue llamado FightingCritters, esta distinción se hace debido a que en juegos como Pokemón se pueden tener varios pokemones pero solo unos seleccionados para peleear, en nuestro caso el máximo de critters para pelear son 3.

# Interfaz Gráfica
Existe un prefab llamado UserInfo este prefab contiene todos los placeholders para mostrar la información necesaria de los FightingCritters de un User en especifico, este prefab contiene el Script llamado UserUI, este se encarga de actualizar la información de los textos, imagenes, botones, en ningun momento guarda referencia a un User o un  Critter, solo los recibe como parámetros en los métodos que estos poseen. UserUi esta diseñada de tal manera que puede recibir un Player y encargarse de poner los botones que son las Skills del Critter que esta peleando, en caso contrario de que sea un EnemyBot no le pone botones debido a que este no necesita y no deberia tener. UserUi se comunica con ButtonPool y SpritesPool, la razón de tener un pool para los botones es que cada vez que un Critter muere los botones se deben actualizar respecto al nuevo Critter que va a pelear y como la cantidad de Skills para un Critter esta entre 1 y 3, no tenemos un valor asegurado de cuantas habilidades tiene un critter, por ejemplo puede que un Critter solo tenga una skill pero que este muere y el siguiente Critter tiene 3 skills, esto me evita tener que crear y destruir botones, solo los reuso. La razón de sprites pool es parecida, solo que una vez mi critter se muere el Image de este regresa al pool, tambien abre posibilidades a cosas como poder agregar Critters a la pelea. 

Otra cosa que vale la pena menciona es como se relaciónan los botones para realizar un DoSkill, y es de la siguiente manera. Se tiene un prefab de Button, este prefab tiene el Script SkillButton que tiene un evento llamado OnButtonPressed<int>, este evento se hace cuando se presióna el boton. Es la responsabilidad de UserUI de asociar el metodo Execute de User, y este execute es el que ultimamente a través de ICommand se refiere al metodo Execute de Gamereferee, entonces lo que se logra aqui es que el button realize un skill sin que este tenga conocimiento alguno de User, o de que user tenga conocimiento alguno de GameReferee.
  
 GameReferee se comunica con UIFacade, UIFacade al igual que UserUI no guarda referencias directas a un User o algún critter si no que los recibe como parámetros, UIFacade se encarga de llamar a los métodos del UserUI, por tanto UIFacade crea la interfaz de ambos jugadores y a través de sus respectivos UserUI las actualiza. En resumén.
 GameReferee ---Se comunica con --> UiFacade ----Se comunica con ---> UserUI.
 
 La clase Stats sigue igual que en el anterior taller.
 
 Nota: Por facilidad para esta demostración GameReferee tiene serializado ambos jugadores, al igual que el UIFacade.
 
 Imágenes tomadas de: https://pokemon.alexonsager.net/
