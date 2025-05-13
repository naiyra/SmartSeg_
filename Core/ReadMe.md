# Core Module – SmartSeg

This folder contains the core **shared contracts and models** used across all modules in the SmartSeg project.

These classes and interfaces define the structure of the data and outputs, and ensure all modules remain **decoupled** and **interoperable**.

---

## Files & Responsibilities

### `IDataFrame.cs`
- Defines a common interface for working with tabular data (similar to a spreadsheet or dataset).
- Used across all modules so they don't rely on a specific implementation like `DataTable`.
- Exposes operations like:
  - `GetColumnNames()`
  - `GetColumnValues()`
  - `Clone()`
  - `SetColumnValues()`

### `SmartDataFrame.cs`
- Concrete class that implements `IDataFrame`.
- Internally uses a `DataTable` to hold and manipulate the dataset.
- Enables modules to read/write tabular data without being aware of its storage format.



By centralizing core contracts and models here:
- All modules work with the **same definitions**.
- The system is easy to extend or replace parts of.
- There's **no direct coupling** between modules like cleaning, engineering, and clustering.

This is what enables full modularity in the SmartSeg architecture.
