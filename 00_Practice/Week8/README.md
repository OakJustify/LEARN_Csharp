# Week 8 - Inheritance & Polymorphism (Hospital System)

A C# console application that implements a **hospital management system** based on a UML class diagram. The program demonstrates object-oriented concepts such as **inheritance**, **method overriding**, **runtime polymorphism**, **upcasting/downcasting**, and **composition**.

---

## 📖 Topic

| Concept | Where it is used |
|---|---|
| Inheritance | `Pasien : Orang`, `TenagaMedis : Orang`, then two levels of subclasses |
| Method Overriding | `Aktivitas()` is `virtual` in `Orang` and overridden in every subclass |
| Runtime Polymorphism | One `List<Orang>`, one call `o.Aktivitas()`, seven different behaviours |
| Upcasting / Downcasting | `PasienAnak` stored as `Orang`, then cast back with `is` / `as` |
| Composition | `RumahSakit` owns a `List<Orang>` (filled diamond in the UML) |
| Encapsulation | `daftarOrang` is `private readonly`, accessed through methods |
| Constructor Chaining | Child constructors call `: base(...)` |
| Pattern Matching | `if (o is PasienAnak pa)` to call subclass-only methods |

---

## 🏗️ Class Hierarchy

```text
RumahSakit  ==<o> (composition) -->  Orang
                                        │
              ┌─────────────────────────┴─────────────────────┐
              │                                               │
           Pasien                                      TenagaMedis
         ┌────┴────┐                                 ┌──────┴──────┐
     PasienAnak  PasienDewasa                    Dokter         Perawat
```

| Class | Parent | Extra members | Own methods |
|---|---|---|---|
| `Orang` | – | `Nama`, `Umur` | `Aktivitas()`, `InfoOrang()`, `Peran()`, `Ringkas()`, `ToString()` |
| `Pasien` | `Orang` | `Keluhan` | `CekKeluhan()` |
| `PasienAnak` | `Pasien` | – | `Menangis()` |
| `PasienDewasa` | `Pasien` | – | `Konsultasi()` |
| `TenagaMedis` | `Orang` | `Spesialisasi` | `CekSpesialis()` |
| `Dokter` | `TenagaMedis` | – | `Diagnosa()` |
| `Perawat` | `TenagaMedis` | – | `CekPasien()` |
| `RumahSakit` | – | `daftarOrang` (private) | `TambahOrang()`, `DaftarOrang()`, `DetailOrang()`, `JumlahOrang`, `JumlahPasien`, `JumlahTenagaMedis`, `DaftarSeluruhOrang()` |

Every subclass overrides `Aktivitas()` with its own behaviour — including the third level (`PasienAnak`, `PasienDewasa`, `Dokter`, `Perawat`), which proves that overriding keeps working at any depth.

---

## 📁 Project Structure

```text
Week8/
├── Week8.csproj          # console project, net10.0, implicit usings
├── Orang.cs              # base class (parent)
├── Pasien.cs             # level 1 subclass
├── PasienAnak.cs         # level 2 subclass
├── PasienDewasa.cs       # level 2 subclass
├── TenagaMedis.cs        # level 1 subclass
├── Dokter.cs             # level 2 subclass
├── Perawat.cs            # level 2 subclass
├── RumahSakit.cs         # composition owner
└── Program.cs            # entry point, namespace Praktikum8.App
```

Each class lives in its own file under the `Praktikum8` namespace; `Program` sits in `Praktikum8.App` and imports it with `using Praktikum8;`.

---

## 🚀 How to Run

```bash
cd 00_Practice/Week8
dotnet run
```

Requirements: .NET SDK 8.0 / 10.0 or later.

---

## 🧪 Demo Cases in `Main()`

| Case | What it demonstrates |
|---|---|
| 1 | Create the `RumahSakit` object, create 6 people, register them with `TambahOrang()` |
| 2 | Display all data — `DaftarOrang()` (formatted table via `ToString()`) and `DetailOrang()` |
| 3 | Polymorphism — a `List<Orang>` of 7 different types, one call to `Aktivitas()` |
| 4 | Calling subclass-only methods using pattern matching (`is`) |
| 5 | Upcasting (implicit) and downcasting (with `is` and `as`) |
| 6 | Polymorphic collections — `List<Pasien>` and `List<TenagaMedis>` |
| 7 | Summary — counting each role with `Count(o => o is ...)` |

---

## 📤 Sample Output

```text
=== KASUS 2: MENAMPILKAN SEMUA DATA (DaftarOrang + InfoOrang) ===

  +---------------+------------------+-------------+
  | KELAS         | NAMA              | UMUR        |
  +---------------+------------------+-------------+
  | Orang         | Pak Budi           |  45 tahun |
  | Pasien        | Ibu Sari           |  32 tahun |
  | PasienAnak    | Andik              |   7 tahun |
  | PasienDewasa  | Pak Hendra         |  55 tahun |
  | Dokter        | Andi               |  41 tahun |
  | Perawat       | Rina               |  29 tahun |
  +---------------+------------------+-------------+
  Total orang terdaftar: 6
```

```text
=== KASUS 3: POLYMORPHISM - SATU METHOD, BANYAK PERILAKU ===

[Orang] Pak Budi (45 th) - Sedang melakukan kegiatan umum di rumah sakit.
[Pasien] Ibu Sari (32 th) - Sedang menunggu giliran berobat, keluhan: Batuk kering.
[PasienAnak] Andik (7 th) - Sedang menangis, perlu dihibur oleh orang tua.
[PasienDewasa] Pak Hendra (55 th) - Sedang berkonsultasi dengan dokter.
[Dokter] dr. Andi (41 th) - Sedang memeriksa pasien sebagai spesialis Penyakit Dalam.
[Perawat] Suster Rina (29 th) - Memantau kondisi pasien dan membantu dokter.
```

---

## 💡 Key Code Snippets

**Overriding a base method**

```csharp
public class Orang
{
    public virtual void Aktivitas() => /* base behaviour */;
}

public class Dokter : TenagaMedis
{
    public override void Aktivitas() => /* doctor behaviour */;
}
```

**Polymorphic call (runtime binding)**

```csharp
List<Orang> daftar = new List<Orang> { new Orang(...), new Dokter(...), new Perawat(...) };
foreach (Orang o in daftar)
    o.Aktivitas();   // executes the version of the actual runtime type
```

**Calling subclass-only methods**

```csharp
foreach (Orang o in rs.DaftarSeluruhOrang())
{
    if (o is PasienAnak pa) pa.Menangis();
    else if (o is Dokter d)    d.Diagnosa();
}
```

**Upcasting and downcasting**

```csharp
Orang jadiOrang = new PasienAnak("Dita", 6, "Demam tinggi"); // implicit upcasting

if (jadiOrang is PasienAnak pa) pa.Menangis();               // safe downcasting
Dokter? d = orangBiasa as Dokter;                           // null if it fails
```

---

## 📝 Notes

- `Aktivitas()` and `Peran()` are `virtual`; `InfoOrang()`, `Ringkas()`, and `CekKeluhan()` / `CekSpesialis()` are inherited without being rewritten (code reusability).
- `daftarOrang` is `private readonly`; `DaftarSeluruhOrang()` returns a copy so the internal list cannot be modified from outside (encapsulation).
- The relationship `RumahSakit ◇─> Orang` is **composition**: the hospital owns the people it stores.

---

## 📚 Related Modules

- [Week3](../Week3) - Inheritance & UML class diagrams
- [Week4](../Week4) - Polymorphism (overloading & overriding)
- [Week7](../Week7) - Abstract classes, interfaces & class libraries

Part of the `LEARN_C#` repository, released under the MIT License.