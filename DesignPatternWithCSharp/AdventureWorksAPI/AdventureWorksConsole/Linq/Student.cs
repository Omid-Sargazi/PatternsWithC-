namespace AdventureWorksConsole.Linq
{
    public class Student
    {
        public string Name { get; set; }
        public List<string> Courses { get; set; }
    }

    public class RunLinq
    {
        public static void Run()
        {
            List<Student> students = new List<Student>
            {
                new Student{Name="Omid",Courses = new List<string>{"Math","Programming"}},
                new Student{Name = "Saedd",Courses = new List<string> {"C#","C++"}}
            };

            var allCourses = students.Select(x => x.Courses);


            List<string> colors = new List<string> { "Green", "Red" };
            List<string> sizes = new List<string> { "S", "X" };

            var combination = colors.SelectMany(color => sizes,
            (color, size) => $"{color},{size}");


            TreeNode root = new TreeNode
            {
                values = "Root",
                Children = {
                    new TreeNode{values="child1"},
                    new TreeNode
                    {
                        values="child2",
                        Children = {new TreeNode{values="Grandchild"}}
                    }
                }
            };


        }

        // IEnumerable<T> SelectMany<TSource, TResult>(
        // this IEnumerable<TSource> source,
        // Func<TSource, IEnumerable<TResult>> selector);


        IEnumerable<string> GetAllValues(TreeNode node)
        {
            return new[] { node.values }.Concat(node.Children.SelectMany(GetAllValues));
        }
    }


    public class TreeNode
    {
        public string values { get; set; }
        public List<TreeNode> Children = new List<TreeNode>();

    }



}