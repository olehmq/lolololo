using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba_9
{
    public class QuestRoom
    {
        private readonly List<IQuestRoomComponent> _components = new List<IQuestRoomComponent>();

        public void AddComponent(IQuestRoomComponent component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(IQuestRoomComponent component)
        {
            _components.Remove(component);
        }

        public void Operate()
        {
            Console.WriteLine("The QuestRoom is operating...");

            foreach (var component in _components)
            {
                component.Operate();
            }
        }
        public IEnumerable<IQuestRoomComponent> GetComponents()
        {
            return _components.SelectMany(c => c.GetComponents()).Concat(_components);
        }
    }
    public interface IQuestRoomComponent
    {
        bool OperateCalled { get; }

        void AddComponent(IQuestRoomComponent component);
        
        void Operate();
        IEnumerable<IQuestRoomComponent> GetComponents();
    }

    
    public class Quest : IQuestRoomComponent
    {
        public void AddComponent(IQuestRoomComponent component)
        {
            
        }

        public void Operate()
        {
            Console.WriteLine("Quest is prepearing...");
        }

        public IEnumerable<IQuestRoomComponent> GetComponents()
        {
            return Enumerable.Empty<IQuestRoomComponent>();
        }
    }

    public class Animators : IQuestRoomComponent
    {
        private readonly List<IQuestRoomComponent> _components = new List<IQuestRoomComponent>();

        public void AddComponent(IQuestRoomComponent component)
        {
            _components.Add(component);
        }

        public void Operate()
        {
            Console.WriteLine("Animators is running...");

            foreach (var component in _components)
            {
                component.Operate();
            }
        }

        public IEnumerable<IQuestRoomComponent> GetComponents()
        {
            return _components.SelectMany(c => c.GetComponents()).Concat(_components);
        }
    }

 
    public class QuestRoomBuilder
    {
        public static QuestRoom Build()
        {
            var QuestRoom = new QuestRoom();
            var Quest = new Quest();
            var Animators = new Animators();
            

            Animators.AddComponent(Quest);
            QuestRoom.AddComponent(Animators);
            

            MessageBox.Show("Quest, Animators added to the QuestRoom.");

            return QuestRoom;
        }
    }

}
