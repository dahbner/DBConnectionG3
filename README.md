# DBConnectionG3
TecWeb Group Project – Event Management
# Lopez Olivares David Hassan, Orozco Veizaga Dabner Eliezer, Rimassa Fernandez Ernesto David

# API with Entities: Books, Guests, and Tickets

This project contains three main classes (Book, Guest, and Ticket) that share the same structure of methods but differ in their attributes.  
Each class has its own service and interface implementing basic CRUD operations.

---

## Book

Attributes  
- Guid Id  
- string Title  
- int Year  

Methods  
- Task<IEnumerable<Book>> GetAll() → Retrieves all books.  
- Task<Book?> GetById(Guid id) → Finds a book by its ID.  
- Task<Book> Create(CreateBookDto dto) → Creates a new book.  
- Task<bool> Delete(Guid id) → Deletes a book by its ID.  

---

## Guest

Attributes  
- Guid Id  
- string FullName  
- bool Confirmed  

Methods  
- Task<IEnumerable<Guest>> GetAll() → Retrieves all guests.  
- Task<Guest?> GetById(Guid id) → Finds a guest by their ID.  
- Task<Guest> Create(CreateGuestDto dto) → Creates a new guest.  
- Task<bool> Delete(Guid id) → Deletes a guest by their ID.  

---

## Ticket

Attributes  
- Guid Id  
- string[]? Notes  

Methods  
- Task<IEnumerable<Ticket>> GetAll() → Retrieves all tickets.  
- Task<Ticket?> GetById(Guid id) → Finds a ticket by its ID.  
- Task<Ticket> Create(CreateTicketDto dto) → Creates a new ticket.  
- Task<bool> Delete(Guid id) → Deletes a ticket by its ID.  

---

Each of these classes is managed through its own service and controller, following a consistent CRUD structure and logic.

