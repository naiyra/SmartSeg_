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

### `ClusteredResult.cs`
- Defines the output of the clustering process.
- Includes:
  - Optimal number of clusters (`K`)
  - Cluster label assignments
  - A reference to the original data with cluster labels added

### `SegmentSummary.cs`
- Used by the interpretation module.
- Represents a human-readable summary of a cluster (segment).
- Includes:
  - A brief description
  - Aggregated statistics (e.g., average age, income)

---

## Why This Folder Matters

By centralizing core contracts and models here:
- All modules work with the **same definitions**.
- The system is easy to extend or replace parts of.
- There's **no direct coupling** between modules like cleaning, engineering, and clustering.

This is what enables full modularity in the SmartSeg architecture.
