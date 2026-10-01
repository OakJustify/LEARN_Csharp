using System;
using System.Collections.Generic;

namespace Praktikum6
{
    // ====================================================
    // 1. ASSOCIATION (Asosiasi)
    // Hubungan interaksi antar-objek TANPA kepemilikan (No Ownership).
    // Objek berdiri independen dan saling berinteraksi lewat parameter method.
    // ====================================================

    public class Course
    {
        public string Name { get; set; }

        public Course(string name)
        {
            Name = name;
        }
    }

    public class Student
    {
        public string Name { get; set; }

        // Interaksi terjadi dengan menerima objek Course sebagai parameter method
        public void Enroll(Course course)
        {
            Console.WriteLine($"{Name} berhasil mendaftar ke mata kuliah '{course.Name}'.");
        }
    }

    // ====================================================
    // 2. AGGREGATION (Agregasi)
    // Hubungan "has-a" dengan Kepemilikan Lemah (Weak Ownership).
    // Objek bagian (Wheel) dibuat terpisah di luar dan dimasukkan ke pemilik (Car).
    // Jika Car dihapus/dihancurkan, objek Wheel TETAP BISA BERDIRI SENDIRI.
    // ====================================================

    public class Wheel
    {
        public string Brand { get; set; }

        public Wheel(string brand)
        {
            Brand = brand;
        }
    }

    public class Car
    {
        public string Model { get; set; }
        public List<Wheel> Wheels { get; set; }

        // Objek Wheel diterima dari luar melalui konstruktor (Dependency Injection)
        public Car(string model, List<Wheel> wheels)
        {
            Model = model;
            Wheels = wheels;
        }

        public void TampilkanSpesifikasi()
        {
            Console.WriteLine($"Mobil {Model} menggunakan {Wheels.Count} roda:");
            foreach (var wheel in Wheels)
            {
                Console.WriteLine($" - Roda Merk: {wheel.Brand}");
            }
        }
    }

    // ====================================================
    // 3. COMPOSITION (Komposisi)
    // Hubungan "has-a" dengan Kepemilikan Kuat (Strong Ownership).
    // Objek bagian (Room) DICIPTAKAN DI DALAM pemilik (House).
    // Lifecycle Room bergantung pada House. Jika House dihapus, Room ikut hancur.
    // ====================================================

    public class Room
    {
        public string Name { get; set; }

        public Room(string name)
        {
            Name = name;
        }
    }

    public class House
    {
        public string Address { get; set; }
        public List<Room> Rooms { get; set; }

        public House(string address)
        {
            Address = address;

            // Instansiasi langsung terjadi di dalam konstruktor House (Strong Ownership)
            Rooms = new List<Room>
            {
                new Room("Ruang Tamu"),
                new Room("Kamar Tidur Utama"),
                new Room("Dapur")
            };
        }

        public void TampilkanDenah()
        {
            Console.WriteLine($"Rumah di alamat '{Address}' memiliki {Rooms.Count} ruangan:");
            foreach (var room in Rooms)
            {
                Console.WriteLine($" - Ruangan: {room.Name}");
            }
        }
    }

    // ====================================================
    // ENTRY POINT PROGRAM
    // ====================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================================");
            Console.WriteLine(" PEMROGRAMAN OOP: RELASI OBJEK (RELATIONSHIP)");
            Console.WriteLine("============================================\n");

            // ----------------------------------------------------
            // DEMO 1: ASSOCIATION (Student & Course)
            // ----------------------------------------------------
            Console.WriteLine("=== 1. ASSOCIATION (Interaksi Tanpa Kepemilikan) ===");
            Student student1 = new Student { Name = "Andi" };
            Course course1 = new Course("Pemrograman C#");

            // Objek 'student1' berinteraksi dengan 'course1', tapi tidak menguasai lifecycle-nya
            student1.Enroll(course1);
            Console.WriteLine("-> Catatan: Jika 'student1' dihapus, objek 'course1' tetap berdiri sendiri di memori.\n");

            // ----------------------------------------------------
            // DEMO 2: AGGREGATION (Car & Wheel)
            // ----------------------------------------------------
            Console.WriteLine("=== 2. AGGREGATION (Weak Ownership - Has-A) ===");
            
            // Objek Wheel dibuat secara mandiri di luar kelas Car
            Wheel wheel1 = new Wheel("Michelin");
            Wheel wheel2 = new Wheel("Bridgestone");
            Wheel wheel3 = new Wheel("Michelin");
            Wheel wheel4 = new Wheel("Bridgestone");

            List<Wheel> daftarRoda = new List<Wheel> { wheel1, wheel2, wheel3, wheel4 };

            // Objek Car dibentuk menggunakan daftar Wheel yang sudah ada
            Car car1 = new Car("Toyota Avanza", daftarRoda);
            car1.TampilkanSpesifikasi();
            Console.WriteLine("-> Catatan: Objek Wheel dibuat di luar Car dan dapat dipindahkan ke mobil lain.\n");

            // ----------------------------------------------------
            // DEMO 3: COMPOSITION (House & Room)
            // ----------------------------------------------------
            Console.WriteLine("=== 3. COMPOSITION (Strong Ownership - Has-A) ===");

            // Objek House dibuat, dan di dalam konstruktornya otomatis membuat objek Room
            House house1 = new House("Jl. Mawar No. 10");
            house1.TampilkanDenah();
            Console.WriteLine("-> Catatan: Objek Room diciptakan internal oleh House. Jika House hancur, Room ikut hancur.");
            Console.WriteLine();
        }
    }
}