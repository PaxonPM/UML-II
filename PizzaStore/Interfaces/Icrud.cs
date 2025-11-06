
namespace PizzaStore.Interfaces
{
    interface Icrud<Tone, Ttwo, Tobject>
    {

        void Create(Tobject Obj);
        void Read(Tone one);
        void Update(Tobject Obj);
        void Delete(Ttwo two);
        

    }
}
