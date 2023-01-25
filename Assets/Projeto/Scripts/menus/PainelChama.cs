using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainelChama : MonoBehaviour
{
    private bool portugues;
    private bool ingles;
    private bool spanish;

    public Text text01;
    public Text text02;
    public Text text03;
    public Text text04;
    public Text text05;


    public GameObject telaInicial;
    public GameObject linguagem;

    private int totalIdiomas;


    // Start is called before the first frame update
    void Start()
    {
        portugues = true;
        totalIdiomas = PlayerPrefs.GetInt("Idioma");
    }

    // Update is called once per frame
    void Update()
    {
        if(ingles == true)
        {
            text01.text = ("On a planet, there was only ocean and a giant garlic, two colossal titans inhabited this planet, moreknown as Luiz Anthonio Zerbinato and Alessandro Lombardi Crisóstomo. Both thought they were alone on this planet and in the incessant search for garlic they end up finding it.bringing and at the same time begin to eat the garlic.However, it was so big that they didn't see each other. Each was off to one side, devouring the garlic. The moment they got close to the middle of the garlic, they met and started to fight, battle in what was known as 'the fight that creates everything', both land simultaneous punches and fall around the rest of garlic, by coincidence they fall in the exact position to form the complete garlic, thus giving rise to Bina Island.");
           
            text02.text = ("On this island there is a group of friends better known as Os Pelotas. 'Os Pelotas' are a group of 6 teenagers, Joseph, Dook Kook, Cardicio, Rodrigo Vacchi, LuciCrazy, Peter Peolple. They are always arguing, fighting and talking non-stop. But they never separate, they love each other like brothers, despite never admitting it. They trained a lot in the gym, but they didn't change the appearance that's the genetics they possessed after they entered a pool that was used for chemical tests. That's why the adult appearance and developed face, despite being teenagers. Joseph with baldness, all of them with the dental arch of an adult, in addition to inexplicable feats and abilities (such as taking 11 in a test worth 10 or diving headfirst into shallow puddles and diving deeply without getting hurt).");

            text03.text = ("They study at the only school in Bina, Binale, the campus is the size of a neighborhood. In Binale there is an American football team, which is a rival of the pelotas, one of the members of the football team is 'Don Foca Jhones', Bina's only sorcerer.");

            text04.text = ("Foca on Jhones with the intention of disturbing Os Pelotas at the school's end of year dance, tries to cast a spell on Lucicrazy, for being with the girl he likes, Foca's intention was to cast a spell to turn Lucicrazy into a bat, however, the spell went wrong, ending up hitting Joseph, and as an effect, Joseph ended up inside Cardicio's head as a cyclope and having some special skills");

            text05.text = ("Joseph is in the real world now lying on the floor of the school court where the end-of-year dance is taking place, all of his firends are trying to wake him up but they can't. To make Joseph leave Cardicio's head and return to the real world, you must escape the magical world created in Cardicio's head, completing all the stages and monsters created by him! (Collect all crowns at the end of stages to unlock the last stage)");
        
        }
        
        else if(portugues == true)
        {
            text01.text = ("Em um planeta, existia apenas oceano, um gigante alho e dois titas colossais, que habitavam esse planeta, mais" +
                " conhecidos como Luiz Zerbinato e Alessandro Crisostomo." +
                " Ambos pensavam que estavam sozinhos neste planeta e na busca incessante pelo alho, eles acabam o encontrando " +
                "e ao mesmo tempo comecam a come-lo. Porém, era tão grande que eles nao se viram. Cada um" +
                " estava de um lado, devorando o alho." +
                "  No momento que eles chegaram próximos ao meio do alho, eles se encontraram e começaram a lutar, batalha " +
                "essa que é conhecida como 'a luta que tudo cria', ambos se acertam socos simultâneos e caem em volta do " +
                "resto de alho, por coincidência eles caem na posição exata para formar o alho completo, dando origem assim a ilha de Bina.");

            text02.text = ("Nessa ilha há um grupo de 6 amigos, mais conhecidos como Os Pelotas. Os Pelotas sao um grupo de 6 adolescentes, Joseca, Tuco Maluco, Cardicio Maudoso, Rodrigo Vacchi, Lucicrazy e Peter People. Eles sempre estão discutindo, brigando e falando sem parar. Mas nunca se separam, se amam como irmãos, apesar de nunca admitirem. Eles treinavam muito na academia, mas não mudavam a aparência, isso é pela a genética que possuíram depois de terem entrado em uma piscina que era usada para testes químicos. Por isso a aparencia de adulto e rosto desenvolvido. Joseph com a calvicie, todos eles com a arcada dentária de um adulto, alem de proezas e habilidades inexplicáveis (como por exemplo tirar 11 em uma prova que vale 10 ou dar mergulhos de cabeca em poças rasas e mergulharem profundamente sem se machucar).");

            text03.text = ("Eles estudam na unica escola de Bina, Binale, que o campus é do tamanho de um bairro. Em Binale tem um time de futebol americano, que e rival dos pelotas, um dos membros desse time é 'Don Foca Jhones', o único feitiçeiro de Bina.");

            text04.text = ("Foca Jhones na intenção de atrapalhar Os Pelotas no baile de fim de ano da escola, tenta lançar um feitiço em Lucicrazy, por estar com a garota que ele gosta, a intenção de Foca era lancar um feitico para transformar Lucicrazy em um morcego, porém o feitiço saiu errado, acabou acertando Joseca, e como efeito colateral, Joseca acabou indo parar dentro da cabeça de Cardicio como um ciclope e com alguns poderes especiais");

            text05.text = ("Joseca se encontra no mundo real agora deitado no chão da quadra da escola onde esta ocorrendo o baile de fim ano, todos Os Pelotas estao tentando acorda-lo mas não conseguem. Para fazer Joseca sair da cabeça de Cardicio e voltar ao mundo real, é preciso escapar do mundo magico criado na cabeca de Cardicio, completando todas as fazes e derrotando monstros criados por ele! (Colete todas as coroas no final das fases para desbloquear a última fase)");

        }
        else if(spanish == true)
        {
            text01.text = ("En un planeta, solo había océano y un ajo gigante, de los colosales titanes que habitaban este planeta, más conocidos como Luiz Anthonio Zerbinato y Alessandro Lombardi Crisostomo. Ambos pensaron que estaban solos en este planeta y en la incesante búsqueda del ajo terminaron encontrándolo. trayendo y al mismo tiempo empezamos a comer el ajo. Sin embargo, era tan grande que no vinieron. Cada uno estaba de un lado, devorando el ajo. En el momento en que se acercaban a la mitad de la mano, se encontraron y comenzaron a pelear, peleando en lo que se conoció como 'la pelea que crea todo', ambos lanzaron golpes simultáneos y cayeron alrededor del resto de la mano, por coincidencia. cayeron en la posición exacta para formar el acto completo, dando paso a Isla Bina.");
            
            text02.text = ("En esta isla hay un grupo de 6 amigos, más conocidos como Os Pelotas. Pelotas somos un grupo de 6 adolescente, Joseca, Antioco Loco, Cardicio Maudoso, Rodrigo Vacchi, Lucicrazy y Peter People. Siempre están discutiendo, peleando y hablando sin parar. Pero nunca se separan, se aman como hermanos, a pesar de no admitirlo nunca. Entrenaron mucho en el gimnasio, pero no cambiaron su apariencia, eso se debe a la genética que poseían después de ingresar a una piscina que se usaba para pruebas químicas. Es por eso que la apariencia de un adulto y una cara desarrollada. Joseph con calvicie, todos ellos con el arco dental de un adulto, además de proezas y habilidades inexplicables (como sacar 11 en una prueba que vale 10 o tirarse de cabeza en charcos poco profundos y sumergirse profundamente sin lastimarse).");
        
            text03.text = ("Estudian en la única escuela de Bina, Binale, cuyo campus es del tamaño de un vecindario. En Binale hay un equipo de fútbol americano, que es rival de las pelotas, uno de los integrantes de este equipo es 'Don Foca Jhones', el único brujo de Bina.");

            text04.text = ("Focus Jhones con la intención de molestar a Os Pelotas en el baile de fin de año de la escuela, intenta hechizar a Lucicrazy, por estar con la chica que le gusta, la intención de Foca era hechizar a Lucicrazy para convertirla en murciélago, pero el hechizo salió mal, terminó golpeando a Joseca, y como efecto secundario, Joseca terminó dentro de la cabeza de Cardicio como un cíclope y con algunos poderes especiales");

            text05.text = ("Joseca está en el mundo real ahora tirado en el piso de la cancha de la escuela donde se lleva a cabo el baile de fin de año, todas las Pelotas están tratando de despertarlo pero no pueden. Para hacer que Joseca deje la cabeza de Cardicio y regrese al mundo real, debes escapar del mundo mágico creado en la cabeza de Cardicio, ¡completando todas las etapas y derrotando a los monstruos creados por él! (Recoge todas las coronas al final de las etapas para desbloquear la última etapa)");
        }
    }


    public void English()
    {
        totalIdiomas = 2;
        ingles = true;
        spanish = false;
        portugues = false;
        linguagem.SetActive(false);
        telaInicial.SetActive(true);
        PlayerPrefs.SetInt("Idioma", totalIdiomas);
    } 
    public void Espanhol()
    {
        totalIdiomas = 3;
        ingles = false;
        spanish = true;
        portugues = false;
        linguagem.SetActive(false);
        telaInicial.SetActive(true);
        PlayerPrefs.SetInt("Idioma", totalIdiomas);
    } 
    public void PtBr()
    {
        totalIdiomas = 1;
        ingles = false;
        spanish = false;
        portugues = true;
        linguagem.SetActive(false);
        telaInicial.SetActive(true);
        PlayerPrefs.SetInt("Idioma", totalIdiomas);
    }



}
