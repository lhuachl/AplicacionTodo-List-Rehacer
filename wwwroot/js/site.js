// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Neuromorphic UI JavaScript Enhancements
// Funcionalidades interactivas para el estilo neuromórfico

document.addEventListener('DOMContentLoaded', function() {
    
    // Inicializar efectos neuromórficos
    initializeNeuromorphicEffects();
    
    // Añadir animaciones suaves
    initializeSmoothAnimations();
    
    // Mejorar formularios
    enhanceForms();
    
    // Agregar feedback visual
    addVisualFeedback();
});

function initializeNeuromorphicEffects() {
    // Efecto de presión para botones neuromórficos
    const neuroButtons = document.querySelectorAll('.neuro-btn');
    
    neuroButtons.forEach(button => {
        button.addEventListener('mousedown', function(e) {
            this.style.transform = 'scale(0.95)';
            this.style.transition = 'transform 0.1s ease';
        });
        
        button.addEventListener('mouseup', function(e) {
            this.style.transform = 'scale(1)';
        });
        
        button.addEventListener('mouseleave', function(e) {
            this.style.transform = 'scale(1)';
        });
    });
    
    // Efecto hover para tarjetas
    const neuroCards = document.querySelectorAll('.neuro-card, .neuro-task-card');
    
    neuroCards.forEach(card => {
        card.addEventListener('mouseenter', function(e) {
            this.style.transition = 'all 0.3s ease';
            this.style.transform = 'translateY(-3px)';
        });
        
        card.addEventListener('mouseleave', function(e) {
            this.style.transform = 'translateY(0)';
        });
    });
}

function initializeSmoothAnimations() {
    // Animación de aparición para elementos
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };
    
    const observer = new IntersectionObserver(function(entries) {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
            }
        });
    }, observerOptions);
    
    // Aplicar animación a contenedores neuromórficos
    const animatedElements = document.querySelectorAll('.neuro-container, .neuro-card, .neuro-task-card');
    
    animatedElements.forEach((element, index) => {
        element.style.opacity = '0';
        element.style.transform = 'translateY(20px)';
        element.style.transition = `opacity 0.6s ease ${index * 0.1}s, transform 0.6s ease ${index * 0.1}s`;
        
        observer.observe(element);
    });
}

function enhanceForms() {
    // Mejorar campos de formulario con efectos neuromórficos
    const formControls = document.querySelectorAll('.neuro-form-control');
    
    formControls.forEach(control => {
        // Efecto focus mejorado
        control.addEventListener('focus', function(e) {
            this.parentElement.classList.add('focused');
            
            // Encontrar el label asociado
            const label = this.parentElement.querySelector('.neuro-label');
            if (label) {
                label.style.color = '#4a90e2';
                label.style.transform = 'translateY(-2px)';
                label.style.transition = 'all 0.2s ease';
            }
        });
        
        control.addEventListener('blur', function(e) {
            this.parentElement.classList.remove('focused');
            
            const label = this.parentElement.querySelector('.neuro-label');
            if (label) {
                label.style.color = '#2c5282';
                label.style.transform = 'translateY(0)';
            }
        });
        
        // Validación en tiempo real visual
        control.addEventListener('input', function(e) {
            if (this.value.length > 0) {
                this.classList.add('has-content');
            } else {
                this.classList.remove('has-content');
            }
        });
    });
}

function addVisualFeedback() {
    // Feedback para acciones del usuario
    
    // Confirmación visual para eliminaciones
    const deleteButtons = document.querySelectorAll('button[onclick*="confirm"]');
    
    deleteButtons.forEach(button => {
        button.addEventListener('click', function(e) {
            // Añadir efecto de vibración
            this.classList.add('neuro-pulse');
            
            setTimeout(() => {
                this.classList.remove('neuro-pulse');
            }, 1000);
        });
    });
    
    // Feedback para formularios enviados
    const forms = document.querySelectorAll('form');
    
    forms.forEach(form => {
        form.addEventListener('submit', function(e) {
            const submitButton = this.querySelector('button[type="submit"]');
            
            if (submitButton) {
                submitButton.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Procesando...';
                submitButton.disabled = true;
                
                // Si hay errores de validación, restaurar el botón
                setTimeout(() => {
                    if (document.querySelector('.field-validation-error:not(:empty)')) {
                        restoreSubmitButton(submitButton);
                    }
                }, 100);
            }
        });
    });
    
    // Toast notifications (si existen mensajes)
    showToastNotifications();
}

function restoreSubmitButton(button) {
    const originalText = button.dataset.originalText || 'Enviar';
    const originalIcon = button.dataset.originalIcon || 'fas fa-save';
    
    button.innerHTML = `<i class="${originalIcon}"></i> ${originalText}`;
    button.disabled = false;
}

function showToastNotifications() {
    // Buscar mensajes de éxito o error en TempData
    const successMessages = document.querySelectorAll('.alert-success');
    const errorMessages = document.querySelectorAll('.alert-danger');
    
    [...successMessages, ...errorMessages].forEach((message, index) => {
        // Añadir animación de entrada
        message.style.opacity = '0';
        message.style.transform = 'translateY(-20px)';
        message.style.transition = 'all 0.3s ease';
        
        setTimeout(() => {
            message.style.opacity = '1';
            message.style.transform = 'translateY(0)';
        }, index * 100);
        
        // Auto-ocultar después de 5 segundos
        setTimeout(() => {
            message.style.opacity = '0';
            message.style.transform = 'translateY(-20px)';
            
            setTimeout(() => {
                message.remove();
            }, 300);
        }, 5000);
    });
}

// Utilidades adicionales
function createRippleEffect(event) {
    const button = event.currentTarget;
    const ripple = document.createElement('span');
    const rect = button.getBoundingClientRect();
    const size = Math.max(rect.width, rect.height);
    const x = event.clientX - rect.left - size / 2;
    const y = event.clientY - rect.top - size / 2;
    
    ripple.style.width = ripple.style.height = size + 'px';
    ripple.style.left = x + 'px';
    ripple.style.top = y + 'px';
    ripple.classList.add('ripple');
    
    button.appendChild(ripple);
    
    setTimeout(() => {
        ripple.remove();
    }, 600);
}

// Añadir efecto ripple a botones
document.addEventListener('click', function(e) {
    if (e.target.classList.contains('neuro-btn')) {
        createRippleEffect(e);
    }
});

// CSS para el efecto ripple
const style = document.createElement('style');
style.textContent = `
    .neuro-btn {
        position: relative;
        overflow: hidden;
    }
    
    .ripple {
        position: absolute;
        border-radius: 50%;
        background: rgba(255, 255, 255, 0.3);
        transform: scale(0);
        animation: ripple-animation 0.6s linear;
        pointer-events: none;
    }
    
    @keyframes ripple-animation {
        to {
            transform: scale(4);
            opacity: 0;
        }
    }
    
    .neuro-form-control.has-content {
        background: #ffffff;
    }
    
    .neuro-form-group.focused .neuro-form-control {
        box-shadow: inset 3px 3px 6px #d1dce8, inset -3px -3px 6px #ffffff, 0 0 0 3px rgba(74, 144, 226, 0.1);
    }
`;

document.head.appendChild(style);

// Función para actualizar el tema dinámicamente (opcional)
function toggleTheme() {
    const root = document.documentElement;
    const currentBg = getComputedStyle(root).getPropertyValue('--primary-bg');
    
    if (currentBg.includes('#f0f4ff')) {
        // Cambiar a tema oscuro neuromórfico
        root.style.setProperty('--primary-bg', '#2d3748');
        root.style.setProperty('--secondary-bg', '#4a5568');
        root.style.setProperty('--shadow-light', '#4a5568');
        root.style.setProperty('--shadow-dark', '#1a202c');
    } else {
        // Volver al tema claro
        root.style.setProperty('--primary-bg', '#f0f4ff');
        root.style.setProperty('--secondary-bg', '#ffffff');
        root.style.setProperty('--shadow-light', '#ffffff');
        root.style.setProperty('--shadow-dark', '#d1dce8');
    }
}

// Función de utilidad para debugging
window.neuromorphicUtils = {
    toggleTheme,
    createRippleEffect,
    showToastNotifications
};
