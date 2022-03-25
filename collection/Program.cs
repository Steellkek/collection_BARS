using System;
using System.Collections.Generic;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //создаем лист Entity
            List<Entity> list = new List<Entity>();
            //добоавляем элементы
            list.Add(new Entity(1, 0, "Root entity"));
            list.Add(new Entity( 2,  1, "Child of 1 entity"));
            list.Add(new Entity( 3,  1, "Child of 1 entity"));
            list.Add(new Entity( 4,  2, "Child of 2 entity"));
            list.Add(new Entity( 5,  4, "Child of 4 entity"));
            //используем метод
            Dictionary<int,List<Entity>> dict = Entity.ToDict(list);

            Console.WriteLine(dict);//для проверки на дебагере

        }
        
        public class Entity
        {
            public int Id;
            public int ParentId;
            public string Name;

            public Entity(int id, int parentId, string name) { Id = id; ParentId= parentId; Name=name; }


            public static Dictionary<int, List<Entity>> ToDict(List<Entity> list)
            {
                Dictionary<int, List<Entity>> dict = new Dictionary<int, List<Entity>>();
                
                foreach (var varEntity in list)
                {
                    //пытаемся добавить новый ключ с элементом
                    if (!dict.TryAdd(varEntity.ParentId,new List<Entity>(){varEntity}))
                    {
                        //если не получилсось, то добавляем элемент в лист по ключу 
                        dict[varEntity.ParentId].Add(varEntity);
                    }
                }
                return dict;
            }
        }
    }
}