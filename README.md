# RestApiTests

Compact .NET API automation example built with NUnit and HttpClient against public NASA endpoints.

## Overview

This repository is a small QA automation project that demonstrates:

- request construction through shared value objects
- JSON response validation
- basic status-code assertions
- reusable helpers for fixture-based comparisons

It is not a full framework, but a compact public sample of API-focused test organization in C#.

## What It Covers

- APOD endpoint checks
- Mars weather endpoint checks
- response field validation against expected JSON values
- simple reusable helper and model structure

## Tech Stack

- `C#`
- `.NET 6`
- `NUnit`
- `HttpClient`
- `System.Text.Json`
- `Newtonsoft.Json`

## Project Structure

- `TestsApi/TestsApi/ApiTests/` test classes
- `TestsApi/TestsApi/Models/` response models
- `TestsApi/TestsApi/Helpers/` JSON helpers and shared logic
- `TestsApi/TestsApi/JsonFiles/` expected comparison values
- `TestsApi/TestsApi/Values/` base URLs, routes, and API key access

## How To Run

Set an API key if you want to use your own:

```powershell
$env:NASA_API_KEY="your_api_key"
```

Then run:

```powershell
dotnet test .\TestsApi\TestsApi\TestsApi.csproj
```

If `NASA_API_KEY` is not set, the project falls back to `DEMO_KEY`.

## Notes

- Public APIs can change behavior over time, so some assertions may need refreshes
- This repo is meant as a small public sample, not as a production-grade enterprise framework
