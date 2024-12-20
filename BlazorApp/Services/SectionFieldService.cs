﻿using BlazorApp.Database;
using BlazorApp.Models;
using System.Data.Entity;

namespace BlazorApp.Services
{
    public class SectionFieldService
    {
        private readonly AgroContext _context;

        public SectionFieldService(AgroContext context)
        {
            _context = context;
        }

        public List<SectionField> GetAllSectionFieldsAsync()
        {
            return _context.SectionFields.Include(p=>p.Field).ToList();
        }
        // Получить все SectionField
        public  List<Field> GetAllFieldsAsync()
        {
            return  _context.Fields.ToList();
        }

        // Получить SectionField по ID
        public SectionField GetSectionFieldByIdAsync(int id)
        {
            return _context.SectionFields.Include(sf => sf.Field).FirstOrDefault(sf => sf.SectionFieldId == id)?? new();
        }

        // Создать SectionField
        public async Task CreateSectionFieldAsync(SectionField sectionField)
        {
            _context.SectionFields.Add(sectionField);
            await _context.SaveChangesAsync();
        }

        // Обновить SectionField
        public async Task UpdateSectionFieldAsync(SectionField sectionField)
        {
            _context.SectionFields.Update(sectionField);
            await _context.SaveChangesAsync();
        }

        // Удалить SectionField
        public async Task DeleteSectionFieldAsync(int id)
        {
            var sectionField = await _context.SectionFields.FindAsync(id);
            if (sectionField != null)
            {
                _context.SectionFields.Remove(sectionField);
                await _context.SaveChangesAsync();
            }
        }
    }
}
