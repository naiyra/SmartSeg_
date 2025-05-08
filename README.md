This is our MsC. project in Software engineering

# SmartSeg – AI-Powered Customer Segmentation Engine

**SmartSeg** is a modular, AI-assisted customer segmentation platform built with .NET.  
It enables data-driven teams to upload datasets, clean and encode data, select relevant features, apply KMeans clustering, and generate human-readable insights — all in a fully decoupled architecture.

---

##  Key Features

- **Dataset Upload & Validation**  
  Uploads CSV datasets and validates format, types, and missing values.

- **Data Cleaning & Encoding**  
  Handles nulls, normalizes formats, and applies label encoding for categorical features.

- **AI-Assisted Feature Selection**  
  Uses OpenAI prompts to suggest optimal features for segmentation.

- **KMeans Clustering Engine**  
  Applies Scikit-learn’s KMeans via Python integration to segment customers.

- **Optimal K Estimation**  
  Uses Elbow and Silhouette methods to recommend the best number of clusters.

- **Readable Reporting**  
  Converts numeric cluster outputs into readable summaries (e.g., “Budget-conscious females aged 25-34”).

---

## Contributors

This project is distributed across 4 developers:

| Developer | Responsibility |
|----------|----------------|
| Dev A     | `DataHandling/` - Uploading, cleaning and preprocessing |
| Dev B     | `FeatureEngineering/` - encoding and Feature selection/extraction |
| Dev C     | `MachineLearning/` - Clustering logic and optimal K |
| Dev D     | `Reporting/` - Interpreting and visualizing clusters |



1. Make sure you have [.NET 7+](https://dotnet.microsoft.com/en-us/download) installed.
2. Clone the repo:
   ```bash
   git clone https://github.com/your-org/SmartSeg.git
   cd SmartSeg
3.before you start working make sure you understand these points: 
- Define Shared Interfaces for Each Stage: you should implement modules with clear interfaces (exp. MachineLearning/ISegmenter.cs, FeatureEngineering/IFeatureSelector.cs)
- Build a Class per Interface (exp. FeatureSelector.cs → implements IFeatureSelector)


